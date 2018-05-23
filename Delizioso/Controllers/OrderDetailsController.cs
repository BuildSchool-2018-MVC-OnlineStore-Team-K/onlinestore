using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("OrderDetails")]
    public class OrderDetailsController : Controller
    {
        [Route("")]
        // GET: OrderDetails
        public ActionResult OrderDetails()
        {
            return View();
        }
    }
}