using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
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
            //取得cookie
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                ViewBag.Authenticated = false;
                return View();
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


            ProductsRepository repo = new ProductsRepository();
            var list = repo.GetAll().OrderByDescending(x => x.ShelfTime);

            return View(list);
        }
    }
}