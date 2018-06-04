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
using WebApplication1.Models;

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

        [Route("")]
        [HttpPost]
        public ActionResult MemberLogin(LoginModel loginModel)
        {
            //從資料庫找到該帳密
            var service = new CheckMember();
            if (service.CheckAccountExist(loginModel.UserId))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, service.GetAccountName(loginModel.UserId, loginModel.UserPw), DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");
                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("loginModel", "使用者名稱或密碼不正確");
            }
            return PartialView();
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Home");
        }

        //[HttpPost]
        //public ActionResult Member()
        //{
        //    return Redirect("Login");
        //}
    }
}