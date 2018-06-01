using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        // GET: Home
        public ActionResult Home()
        {
            ProductsService item = new ProductsService();
            var list = item.ProductHome().OrderByDescending((x) => x.Sum);

            //取得cookie
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                ViewBag.Authenticated = false;
                return View(list);
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            if (ticket.UserData == "fblogin")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = ticket.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }

            return View(list);
        }
    }
}