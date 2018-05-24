using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Disclaimer")]
    public class DisclaimerController : Controller
    {
        [Route("")]
        // GET: Disclaimer
        public ActionResult Disclaimer()
        {
            return View();
        }
    }
}