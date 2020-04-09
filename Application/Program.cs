using Castle.Windsor;
using Contracts;
using DI;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(new ApplicationInstaller(), new AutomapperInstaller());
            var service = container.Resolve<IService>();
            var fuu = service.GetFuu(1);
        }
    }
}
