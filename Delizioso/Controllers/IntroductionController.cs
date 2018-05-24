using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Introduction")]
    public class IntroductionController : Controller
    {
        [Route("")]
        // GET: Introduction
        public ActionResult Introduction()
        {
            return View();
        }

        public ActionResult Jump()
        {
            return Redirect("Introduction");
        }
    }
}