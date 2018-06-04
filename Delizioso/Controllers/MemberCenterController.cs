using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("MemberCenter")]
    public class MemberCenterController : Controller
    {
        [Route("")]
        // GET: MemberCentre
        public ActionResult MemberCenter()
        {
            return View();
        }
    }
}