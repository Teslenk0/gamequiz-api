using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace gamequiz_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /**
             * First parameter: URL,
             * Second parameter: header
             * Third paramenter: methods
             * **/
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Configuración y servicios de API web
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new JwtHandler());
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
