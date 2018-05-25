using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("register")]
    public class RegisterController : Controller
    {
        // GET: Register
        [Route("")]
        [HttpPost]
        public ActionResult Index(RegisterModel registerModel)
        {
            //檢查帳號 是否重複


            return View();
        }

        [Route("")]
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}