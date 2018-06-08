//using Deliozo.NorthWindModels;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("orders")]
    public class CartController : Controller
    {

        [Route("CartModel")]
        public ActionResult modeltest()
        {
            var obj = new SampleObject
            {
                Name = "david",
                Phone = "0987654321",
            };
            var json = JsonConvert.SerializeObject(obj, Formatting.None);




            //response
            var cookie = new HttpCookie("name");
            cookie.Value = "my_cookie_is_here";
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMinutes(3);
            Response.Cookies.Add(cookie);
            //request
            cookie = Request.Cookies["name"];



            var app = Request.RequestContext.HttpContext.Application;
            //get app state value
            app.Get("key");
            app.Set("key", "value");
            app.Remove("key");
            app.Clear();





            //ViewDataDictionary
            ViewData.Add("data", "0001"); //using viewdata to store data
            //ViewBag
            ViewBag.DataC = "0002";  //the storage source is the same as view data
            //TempData
            TempData.Add("data", "0003");  //using Session to store data


            ViewBag.HtmlData = "<h3>Raw Data</h3>";



            return PartialView(obj);
        }

        public ActionResult DiaplayCustomerCount()
        {
           // var db = new NorthWind();
           // var count = db.Customers.Count();
            return View();
        }




        [Route("")]
        // GET: Demo
        public ActionResult Index()
        {

            //var CartService1 = new CartService();
            //var query = CartService1.GetCartProducts(1, 6);
            //decimal TotalPrice = 0;
            //foreach (var item in query)
            //{
            //    TotalPrice += item.Total;
            //}
            //ViewBag.Total = TotalPrice;
            //return PartialView(query);
            return PartialView();
            
        }
        

        public class SampleObject
        {
            public string Name { get; set; }
            public string Phone { get; set; }
        }


        public ActionResult CreateCustomer()
        {

            return View();
        }
        /* 需要修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer model)
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];

            return View();
        }
        */
        public ActionResult CreateOrder()
        {
            return View();
        }

        [Route("checkorder")]
        public ActionResult CheckOrder()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var service = new CartService();
            var result = service.GetCartProducts((ticket.Name.Split(',')[1]));
            return View(result);
        }

        [Route("checkorder")]
        [HttpPost]
        public ActionResult CheckOrder(string n)
        {

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var UserAccount = ticket.Name.Split(',')[1];
            var service = new CartService();
            var MemberId = service.GetMemberIdByAccount(UserAccount);
            var OrderID = service.GetCartOrderIDByMemberID(MemberId);
            bool alter = service.AlterCartToOrders(MemberId, OrderID);

            var url = "";
            if (alter)
            {
                url = "~/orders/shippingpayment";
            }
            else
            {
                ViewBag.StatusFail = "發生錯誤 請重試!";
            }

            return Redirect(url);
        }

        //var UserAccount = ticket.Name.Split(',')[1];

        [Route("shippingpayment")]
        public ActionResult ShippingPayment()
        {
            return View();
        }
        [Route("shippingpayment")]
        [HttpPost]
        public ActionResult ShippingPayment(string value)
        {
            return Redirect("~/orders/deliveryinformation");
        }


        [Route("deliveryinformation")]
        public ActionResult DeliveryInformation()
        {
            return View();
        }



        [Route("completetheorder")]
        public ActionResult CompleteTheOrder()
        {
            return View();
        }
    }
}