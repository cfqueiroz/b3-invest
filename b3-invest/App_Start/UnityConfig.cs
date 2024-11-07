using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using calculo_b3.Services;


namespace calculo_b3
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // Cria��o do cont�iner do Unity
            var container = new UnityContainer();

            // Registro da interface ICdbService e sua implementa��o CdbService
            container.RegisterType<ICdbService, CdbService>(new HierarchicalLifetimeManager());

            // Configura��o do DependencyResolver para o Web API com Unity
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
