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
            

            ViewBag.FBresponse(o);


            return View();
        }
    }
}