using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApiOficial
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "dd-MM-yyyy hh:mm:ss",
                Culture = new CultureInfo("pt-BR"),
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonFormatter.SerializerSettings = jsonSerializerSettings;
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
