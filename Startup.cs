using System;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;
using OwinSelfHost;
using System.Collections.Generic;
using System.Text;



using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Radacode_OWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule));
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",               
                routeTemplate: "api/{controller}/{action}/{id}", 
                defaults: new { id = RouteParameter.Optional }
            );


            /*
                        app.Use(new Func<AppFunc, AppFunc>(next =>
                            env => {
                                var headers = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];
                                headers.Add("Content-Type", new[] { "text/plain; charset=utf-8" });

                                var outstream = (System.IO.Stream)env["owin.ResponseBody"];
                                var buffer = Encoding.UTF8.GetBytes("Извините, но запрошенный адрес не существует.");
                                return outstream.WriteAsync(buffer, 0, buffer.Length);
                            }));
            */
            // Web Api
            app.UseWebApi(config);           

        }
    }
}
