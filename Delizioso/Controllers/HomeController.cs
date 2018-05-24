using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        // GET: Home
        public ActionResult Home()
        {
            ProductsRepository repo = new ProductsRepository();
            var list = repo.GetAll().OrderByDescending(x => x.ShelfTime);

            return View(list);
        }
    }
}