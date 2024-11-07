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
            // Criação do contêiner do Unity
            var container = new UnityContainer();

            // Registro da interface ICdbService e sua implementação CdbService
            container.RegisterType<ICdbService, CdbService>(new HierarchicalLifetimeManager());

            // Configuração do DependencyResolver para o Web API com Unity
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
