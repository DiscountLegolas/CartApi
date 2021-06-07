using CartApi.Data;
using CartApi.Data.Repositorys;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CartApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cont = new SimpleInjector.Container();
            cont.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            cont.Register<ICartRepo, CartRepo>(Lifestyle.Scoped);
            cont.Register<IProductRepo, ProductRepo>(Lifestyle.Scoped);
            cont.Register<IUserRepo, UserRepo>(Lifestyle.Scoped);
            cont.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            cont.Verify();
            config.DependencyResolver= new SimpleInjectorWebApiDependencyResolver(cont);
            // Web API yapılandırması ve hizmetleri
            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));
            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
