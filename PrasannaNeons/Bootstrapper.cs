using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using PrasannaNeons.Controllers;
using PrasannaNeons.Data;

namespace PrasannaNeons
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IStatelessRepository, StatelessRepository>();
            container.RegisterType<IController, HomeController>("Home");
            container.RegisterType<IController, AccountController>("Account");
            container.RegisterType<IController, ServicesController>("Services");   

            return container;
        }
    }
}