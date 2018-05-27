using Newtonsoft.Json.Linq;
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
    [RoutePrefix("auth")]
    public class GoogleAuthenticationController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            var redirectURL = "https://accounts.google.com/o/oauth2/v2/auth?" +
                "client_id=" + ConfigurationManager.AppSettings["google:key"] +
                "&redirect_uri=" + HttpUtility.UrlEncode("https://delizioso.azurewebsites.net/auth/google") +
                "&scope=https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile" +
                "&response_type=code";
            return Redirect(redirectURL);
        }

        [Route("google")]
        // GET: Authentication
        public ActionResult Google()
        {
            var code = Request.QueryString["code"];
            var tokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";
            var payload =
                $"code={code}" +
                $"&client_id={ConfigurationManager.AppSettings["google:key"]}" +
                $"&client_secret={ConfigurationManager.AppSettings["google:secret"]}" +
                $"&redirect_uri={HttpUtility.UrlEncode("https://delizioso.azurewebsites.net/auth/google")}" +
                $"&grant_type=authorization_code";

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = client.UploadString(tokenEndpoint, payload);

            var o = JObject.Parse(response);
            var accessToken = o.Property("access_token").Value.ToString();
            

            var profile = client.DownloadString("https://www.googleapis.com/plus/v1/people/me?access_token=" + accessToken);

            ViewBag.Google = (profile);
            return View();
        }

    }




}