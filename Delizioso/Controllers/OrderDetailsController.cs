using BuildSchool.MVCSolution.OnlineStore.Repository;
using Service;
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
            var service = new OrderDetailService();
            var result = service.GetMemberOrderDetail(1);
            decimal total = 0;
            foreach(var item in result)
            {
                total += Convert.ToDecimal(item.UnitPrice * item.Quantity * (1 - item.Discount));
            }
            ViewBag.Total = total;
            return View(result);
        }
    }
}