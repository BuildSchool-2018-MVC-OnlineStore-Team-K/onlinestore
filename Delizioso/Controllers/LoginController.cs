using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        // GET: Login
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Test = "testStringwerjewr";
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(cookie == null)
            {
                ViewBag.Authenticated = false;
                return View();
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            if(ticket.UserData == "abcdefg")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = ticket.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }
            return View();
        }


        [Route("")]
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if(loginModel.Username == "admin" && loginModel.Password =="adminpwd")
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,"admin",DateTime.Now, DateTime.Now.AddMinutes(30) ,false ,"abcdefg");
                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("loginModel", "使用者名稱或密碼不正確");
            }
            return View();
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }

    }
}