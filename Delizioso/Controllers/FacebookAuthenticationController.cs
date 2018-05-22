using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("facebookauth")]
    public class FacebookAuthenticationController : Controller
    {
        // GET: FacebookAuthentication
        [Route("")]
        public ActionResult Index()
        {


            


            return View();
        }
    }
}