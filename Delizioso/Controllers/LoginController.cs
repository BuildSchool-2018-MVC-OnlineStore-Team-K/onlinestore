using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
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
    [RoutePrefix("login")]
    public class LoginController : Controller
    {
        // GET: Login

        [Route("")]
        [HttpPost]
        public ActionResult MemberLogin(LoginModel loginModel)
        {
            //從資料庫找到該帳密
            var service = new MemberService();
            if(service.CheckAccountExist(loginModel.UserId))
            {
                var data = service.GetAccountName(loginModel.UserId, loginModel.UserPw);
                data += "," + loginModel.UserId;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,data,DateTime.Now,DateTime.Now.AddMinutes(30),false, "abcdefg");
                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                return Redirect("Home");
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

            return Redirect("~/Home");
        }

        public ActionResult Status()
        {

            return PartialView();
        }

    }
}