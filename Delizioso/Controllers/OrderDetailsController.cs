//using Deliozo.NorthWindModels;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [RoutePrefix("orders")]
    public class OrderDetailsController
    {
        [Route("OrderDetails")]
        public ActionResult OrderDetailsViews()
        {

            var db = new OrdersRepository();
            var query = db.GetAll();

            return View(query);
        }

        private ActionResult View(IEnumerable<Orders> query)
        {
            throw new NotImplementedException();
        }
    }
}