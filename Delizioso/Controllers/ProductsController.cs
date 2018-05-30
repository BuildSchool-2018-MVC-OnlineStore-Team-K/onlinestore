using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Product")]
    public class ProductsController : Controller
    {
        // GET: Products
        [Route("{id}")]
        public ActionResult SimpleProduct(int id)
        {
            var controller = new ProductsService();
            var product = controller.GetProductDetailById(id);
            ViewBag.result = product;
            return View();
        }
    }
}