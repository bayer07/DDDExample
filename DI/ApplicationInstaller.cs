using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
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
}
