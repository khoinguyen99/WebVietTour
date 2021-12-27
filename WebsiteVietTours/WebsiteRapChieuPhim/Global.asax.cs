using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebsiteRapChieuPhim
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application.Lock();
            System.IO.StreamReader sr;
            sr = new System.IO.StreamReader(Server.MapPath("~/Views/Home/SL.txt"));
            string S = sr.ReadLine();
            string S1 = sr.ReadLine();
            sr.Close();
            Application.UnLock();
            Application["accesstimess"] = S;
            

        }


        void Session_Start(object sender, EventArgs e)
        {
            if (Session["online"] == null)
            {
                Session["online"] = 1;
            }
            else
            {
                Session["online"] = int.Parse(Session["online"].ToString()) + 1;
            }
            Application["accesstimess"] = int.Parse(Application["accesstimess"].ToString()) + 1;
            
            System.IO.StreamWriter wr;
            wr = new System.IO.StreamWriter(Server.MapPath("~/Views/Home/SL.txt"));
            wr.Write(Application["accesstimess"].ToString());
             
            wr.Close();

        }

        void Session_End(object sender, EventArgs e)
        {

            Session["online"] = int.Parse(Session["online"].ToString()) - 1;



        }
    }
}
