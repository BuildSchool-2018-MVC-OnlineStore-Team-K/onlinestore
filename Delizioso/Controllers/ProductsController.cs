using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BuildSchool.MVCSolution.OnlineStore.Models;
using Service;
using ViewModels;

namespace WebApplication1.Controllers
{
    [RoutePrefix("product")]  //Product/1
    public class ProductsController : Controller
    {
        // GET: Products
        [Route("{id}")]
        public ActionResult SimpleProduct(int id)
        {
            var products_service = new ProductsService();
            //var discounts_service = new DiscountsService();  目前沒折扣資料 先不抓
            var size_service = new SizeService();
            var stockcolor_service = new StockColorService();
            //var image_service = new ImageService();  沒照片 不抓

            var list = new List<SizeStockCombineViewModel>();
            foreach (var i in products_service.GetProductsTable())
            {
                if (id == i.ProductID)
                {
                    ViewBag.ProductName = i.ProductName;

                    ViewBag.ProductID = i.ProductID;
                    ViewBag.UnitPrice = i.UnitPrice;
                    break;
                }
            }

            var size = size_service.GetSizeTable().Where(x => x.ProductID == id).ToList();
            var stockcolor = stockcolor_service.GetStockColorsTable(id).ToList();
            list.Add(new SizeStockCombineViewModel()
            {
                Size = size,
                StockColor = stockcolor
            });

            return View(list);
        }

        //now edit
        [Route("{id}")]
        [HttpPost]
        public ActionResult SimpleProduct(AddToCartViewModel viewmodel)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var UserAccount = ticket.Name.Split(',')[1];

            var product_service = new ProductsService();
            product_service.AddToCart(viewmodel, UserAccount);

            var tmp = viewmodel;

            return Redirect("~/orders/checkorder");
        }

        [Route("all")]
        public ActionResult AllProducts(string category)
        {
            var service = new ProductsService();
            return View(service.GetProductsByCategory(category));
        }

        //[Route("all")]
        //[HttpPost]
        //public ActionResult AllProducts(string category)
        //{
        //    var tmp = category;
        //    var service = new ProductsService();
        //    return View(service.GetProductsByCategory(category));
        //}
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