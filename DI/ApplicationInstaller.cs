using System.Linq;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contracts;
using Dao;
using Domain;
using Infrastructure.Application;

namespace DI
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IService>().ImplementedBy<Service>(),
                Component.For<IUserDao>().ImplementedBy<UserDao>());
        }
    }

    public class AutomapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyInThisApplication(GetType().Assembly)
                    .BasedOn<Profile>().WithServiceBase());

            container.Register(Component.For<IConfigurationProvider>().UsingFactoryMethod(kernel =>
            {
                return new MapperConfiguration(configuration =>
                {
                    kernel.ResolveAll<Profile>().ToList().ForEach(configuration.AddProfile);
                });
            }).LifestyleSingleton());

            container.Register(
                Component.For<IMapper>().UsingFactoryMethod(kernel =>
                    new Mapper(kernel.Resolve<IConfigurationProvider>(), kernel.Resolve)));
        }
    }

    public class SomeProfile : Profile
    {
        public SomeProfile()
        {
            CreateMap<DomainFuu, ApplicationFuu>()
                .ForMember(d => d.ApplicationName, opt => opt.MapFrom(x => x.Name));
        }
    }
}
