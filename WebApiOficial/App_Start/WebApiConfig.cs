using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiOficial
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Clear();

            config.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}"
            );
        }
    }
}
