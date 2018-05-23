using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;

namespace WebApplication1.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        //[Route("db.OrderByShelfTime")]
        public ActionResult OrderByShelfTimeDESC()
        {
            var db = new ProductsRepository();
            var query = db.OrderByShelfTimeDESC();
            return PartialView(query);
        }
    }
}