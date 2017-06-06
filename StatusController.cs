using System.Collections.Generic;
using System.Web.Http;

namespace Radacode_OWIN
{
    [RoutePrefix("api/status")]
    public class StatusController : ApiController
    {
        [HttpGet]
        public bool CheckStatus()
        {
            return true;  // http://localhost:8080/api/Status/CheckStatus
        }       
    }
}
