using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSchool.MVCSolution.OnlineStore.Repository;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        // GET: Home
        public ActionResult Home()
        {          
            return View();
        }
    }
}