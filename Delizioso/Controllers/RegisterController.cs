using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("register")]
    public class RegisterController : Controller
    {
        // GET: Register
        

        [Route("")]
        public ActionResult Index()
        {

            return PartialView();
        }


        [Route("")]
        [HttpPost]
        public ActionResult Index(RegisterModel registerModel)
        {
            var service = new CheckMember();
            if (!service.CheckAccountExist(registerModel.Account))
            {
                ModelState.AddModelError("registerModel", "此帳號已註冊過");
            }

            if (!service.CheckAccountAndPasswordRegister(registerModel.Account,registerModel.Password))
            {
                ModelState.AddModelError("registerModel", "密碼長度請介於6~16個字元");
            }

            if (!service.CheckPhoneRegister(registerModel.Phone))
            {
                ModelState.AddModelError("registerModel", "請輸入您的手機號碼10碼");
            }

            if (!service.CheckCreateAccount(registerModel))
            {
                ModelState.AddModelError("registerModel", "建立錯誤!請聯絡客服人員");
            }


            var url = "~/Home";

            return Redirect(url);
        }


    }
}