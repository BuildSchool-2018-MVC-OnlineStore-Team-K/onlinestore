using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using ViewModels;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Product")]  //Product/1
    public class ProductsController : Controller
    {
        // GET: Products
        [Route("{id}")]
        public ActionResult SimpleProduct(int id)
        {
            var controller = new ProductsService();
            var product = controller.GetProductDetailAll(id);

            var productdetail = controller.GetProductDetail(product, id);
            ViewBag.productname = productdetail.ProductName;
            ViewBag.Category = productdetail.Category;
            ViewBag.unitprice = productdetail.UnitPrice;
            ViewBag.picture = productdetail.Picture;

            var distinctsize = controller.DistinctSize(product);
            ViewBag.distinctsize = distinctsize;
            
            //var distinctcolor = DisplayProductColor(product,id,);
            //ViewBag.distinctcolor = distinctcolor;


            //var productColorStock = DisplayProductStock(product, id,,);
            //ViewBag.productColorStock = productColorStock;
            return View();
        }

        //public ActionResult DisplayProductColor(IEnumerable<ProductsViewModel> list, int productid, string sizetype)
        //{
        //    var db = new ProductsService();
        //    var color = db.ProductColorStock(list,productid,);
        //    return PartialView(color);  //部分顯示
        //}

        //public ActionResult DisplayProductStock(IEnumerable<ProductsViewModel> list, int productid, string sizetype,string color)
        //{
        //    var db = new ProductsService();
        //    var stock = db.ProductColorStock(list, productid,,);
        //    return PartialView(stock);  //部分顯示
        //}
    }
}