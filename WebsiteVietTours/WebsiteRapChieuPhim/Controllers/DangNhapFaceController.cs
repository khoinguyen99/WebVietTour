using System;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;
using System.Configuration;
using System.Web.Security;
using Newtonsoft.Json;
namespace WebsiteRapChieuPhim.Controllers
{
    public class DangNhapFaceController : Controller
    {
        
        // GET: DangNhapFace
        public ActionResult Index()
        {

            return View();
        }
        admincontext dbs = new admincontext();
        private Uri RediredtUri

        {

            get

            {

                var uriBuilder = new UriBuilder(Request.Url);

                uriBuilder.Query = null;

                uriBuilder.Fragment = null;

                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;

            }

        }




        [AllowAnonymous]

        public ActionResult Facebook()

        {

            var fb = new FacebookClient();

            var loginUrl = fb.GetLoginUrl(new

            {




                client_id = "442470896808427",

                client_secret = "c6017bf2c4ed872aa5803a1a3fa33efd",

                redirect_uri = RediredtUri.AbsoluteUri,

                response_type = "code",

                scope = "email"



            });

            return Redirect(loginUrl.AbsoluteUri);

        }




        public ActionResult FacebookCallback(string code)

        {

            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = "442470896808427",

                client_secret = "c6017bf2c4ed872aa5803a1a3fa33efd",

                redirect_uri = RediredtUri.AbsoluteUri,

                code = code




            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");

            string email = me.email;

            TempData["email"] = me.email;

            TempData["first_name"] = me.first_name;

            TempData["lastname"] = me.last_name;

            TempData["picture"] = me.picture.data.url;

            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("TrangChu", "Home");

        }
    }
}