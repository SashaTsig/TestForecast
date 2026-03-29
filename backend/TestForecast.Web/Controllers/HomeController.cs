using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace TestForecast.Web.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}
