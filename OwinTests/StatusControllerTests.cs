using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radacode_OWIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Radacode_OWIN.Tests
{
    [TestClass()]
    public class StatusControllerTests
    {
        [TestMethod()]
        public void CheckStatusTest()
        {
            //arrange           
            var controller = new StatusController();
            controller.Request = new HttpRequestMessage()
               {
                 RequestUri = new Uri("http://localhost:8080/api/Status/C1heckStatus")
               };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
            route: new HttpRoute(),
            values: new HttpRouteValueDictionary { { "controller", "Status" } });

            // Act           
            var response = controller.CheckStatus();

                        //assert
            //Assert.AreEqual("http://localhost:8080/api/Status/CheckStatus", (bool)response.ToString());
            Assert.AreEqual(true, response);
             

        }
    }
}