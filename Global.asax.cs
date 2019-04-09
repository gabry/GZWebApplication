using GZWebApplication.Controllers;
using GZWebApplication.Models;
using NSwag.AspNet.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace GZWebApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteTable.Routes.MapOwinPath("swagger", app =>
            {
                app.UseSwaggerUi3(typeof(WebApiApplication).Assembly, settings =>
                {
                    settings.MiddlewareBasePath = "/swagger";
                    settings.GeneratorSettings.DefaultUrlTemplate = "api/{controller}/{action}/{id}";  //this is the default one
                    settings.GeneratorSettings.Title = "GZ Web Application";
                    settings.GeneratorSettings.DefaultEnumHandling = NJsonSchema.EnumHandling.CamelCaseString;
                });
                app.UseSwaggerReDoc(new System.Collections.Generic.List<System.Reflection.Assembly>
                {
                    typeof(ProductsController).Assembly,
                    typeof(Product).Assembly
                });
            });
        }
    }
}
