using Castle.Windsor;
using DI;
using Domain;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(new ApplicationInstaller());
            var service = container.Resolve<IService>();
            var user = service.GetUser(1);
        }
    }
}
