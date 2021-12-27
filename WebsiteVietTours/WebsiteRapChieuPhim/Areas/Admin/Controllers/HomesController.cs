using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Areas.Admin.Controllers
{
    public class HomesController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(admin tt)
        {


            dangNhap dn = new dangNhap();
            int id = dn.checklogin(tt.email, tt.password);

            if (id >= 1)
            {
                Session["id"] = id;
                if (dn.IsAdmin(id))
                {
                    Session["ten"] = tt.email;
                    ViewBag.mess = "Đăng nhập thành công";
                    return RedirectToAction("layoutIndex", "Homes");
                }
                else
                {
                    ViewBag.mess = "Tài khoản không được cấp quyền Admin";

                }

            } else
            {

                ViewBag.mess = "Tài khoản hoặc mật khẩu không chính xác";
            }

            return View();


        }
        public ActionResult register()
        {

            return View();

        }
        [HttpPost]
        public ActionResult register(admin tt)
        {
            if (ModelState.IsValid)
            {

                dangNhap ad = new dangNhap();

                ad.AddDuLieu(tt);

                Response.Write("<script>alert('Đăng ký thành công !!!');</script>");

                return View("login");

            }
            return View();

        }
        public ActionResult logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("login", "Homes");

        }
    

        public ActionResult layoutIndex()
        {

            return View("layoutIndex");


        }
        [HttpPost]
        public ActionResult layoutIndex(string id = "")
        {
            id = Session["ten"].ToString();
            if (id == null)
            {
                return RedirectToAction("login", "Homes");
            }
            else
            {
                return View("layoutIndex");
            }

        }
    } 

}