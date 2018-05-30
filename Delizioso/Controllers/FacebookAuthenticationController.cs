using Newtonsoft.Json.Linq;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("facebookauth")]
    public class FacebookAuthenticationController : Controller
    {
        // GET: FacebookAuthentication
        [Route("")]
        public ActionResult Index()
        {

            var redirectUrl = "https://www.facebook.com/v3.0/dialog/oauth?" +
                "client_id=616223568711883" +
                "&redirect_uri="+ HttpUtility.UrlEncode("https://delizioso.azurewebsites.net/facebookauth/facebook") +
                "&response_type=code";

            return Redirect(redirectUrl);
        }

        [Route("facebook")]
        public ActionResult Facebook()
        {
            var code = Request.QueryString["code"];
            var tokenEndpoint = "https://graph.facebook.com/v3.0/oauth/access_token";
            
            var payload = "client_id=616223568711883" +
            "&redirect_uri=" + HttpUtility.UrlEncode("https://delizioso.azurewebsites.net/facebookauth/facebook") +
            "&client_secret=" + ConfigurationManager.AppSettings["facebook:secret"] +
            "&code=" + code;

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = client.UploadString(tokenEndpoint, payload);

            var o = JObject.Parse(response);
            var accessToken = o.Property("access_token").Value.ToString();

            ViewBag.accessToken = (accessToken);

            var profile = client.DownloadString("https://graph.facebook.com/me?access_token=" + accessToken);

            var Info = JObject.Parse(profile);
            var id = Info.Property("id").Value.ToString();
            var name = Info.Property("name").Value.ToString();

            ViewBag.Facebook = (id);



            
            //檢查是否已經用fb註冊過
            var service = new CheckMember();
            if (service.CheckFbRegistered(id)) //true是註冊過
            {
                //給予cookie 已登入的狀態
                var url = "~/Home";
                return Redirect(url);
            }
            else //透過FB ID註冊到資料庫
            {
                service.FbRegist(id, name);

            }

            return View();

        }



    }
}