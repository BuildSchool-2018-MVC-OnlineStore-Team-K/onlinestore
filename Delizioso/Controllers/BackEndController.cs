using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("backend")]
    public class BackEndController : Controller
    {
        [Route("products")]
        // GET: BackEnd
        public ActionResult ProductsManage()
        {
            return View();
        }
    }
}