using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("MemberCentre")]
    public class MemberCentreController : Controller
    {
        [Route("")]
        // GET: MemberCentre
        public ActionResult MemberCentre()
        {
            return View();
        }
    }
}