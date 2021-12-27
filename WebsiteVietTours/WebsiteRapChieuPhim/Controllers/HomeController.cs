using System;
using Facebook;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;
using PagedList;
using System.Configuration;

namespace WebsiteRapChieuPhim.Controllers
{
    public class HomeController : Controller
    {
        public object Viewbag { get; private set; }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult TuorKhuyenMai(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);


            return View(bb.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult DatTours()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DatTours(thongTinTour tt)
        {

            if (ModelState.IsValid)
            {


                if (Session["user"] != null) {

                    AddThongTin ad = new AddThongTin();

                    ad.addDulieu(tt);

                    Response.Write("<script>alert('Đặt tour thành công !!!');</script>");




                    return View("DatTours");
                }
                else {
                    Response.Write("<script>alert('Bạn cần đăng nhập để Đặt Tour !!!');</script>");
                }


            }

            return View();
        }

        public ActionResult chitietTour(string id = "")
        {
            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);
            qlb.tourHot(id);

            return View(bb.FirstOrDefault());
        }

        public ActionResult thanhToan()
        {
            return View();
        }
        public ActionResult thueXe()
        {

            return View();
        }
        public ActionResult loginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginUser(admin tt)
        {
            dangNhap dn = new dangNhap();
            int id = dn.checklogin(tt.email, tt.password);


            if (id >= 1)
            {

                if (!dn.IsAdmin(id))
                {
                    Session["id"] = id;
                    Session["user"] = tt.email;
                    Session["pass"] = tt.password;

                    ViewBag.mess = "Đăng nhập thành công";
                    return RedirectToAction("TrangChu", "Home");
                }
                else
                {
                    ViewBag.mess = "Tài khoản không hợp lệ";
                    //return RedirectToAction("loginUser", "Home");
                }

            }
            else
            {

                ViewBag.mess = "Tài khoản hoặc mật khẩu không chính xác";

            }

            return View();

        }

        public ActionResult registerUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult registerUser(admin tt)
        {
            if (ModelState.IsValid)
            {

                dangNhap ad = new dangNhap();
                int user = ad.checkE(tt.username);
                int emails = ad.checkEs(tt.email);

                if (user >= 1)
                {
                    ViewBag.es = "Username đã tồn tại";
                    if (emails >= 1)
                    {
                        ViewBag.errorEmail = "Email đã tồn tại";
                    }


                }
                else if (emails >= 1)
                {
                    ViewBag.errorEmail = "Email đã tồn tại";
                }
                else
                {
                    ad.AddDuLieu(tt);
                    Response.Write("<script>alert('đăng ký thành công !!!');</script>");
                }


            }

            return View();
        }

        public ActionResult logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }

        
        public ActionResult xoaodertour(string id = "") {




            
            AddThongTin tt = new AddThongTin();
           
            tt.deletedulieus(id);
            return RedirectToAction("tourDaDat","Home");
            

        }
        public ActionResult tourDaDat(string id="")
        {
            AddThongTin tt = new AddThongTin();
            List<thongTinTour> bb = tt.tttour(id);
            return View(bb);
        }





            public ActionResult TourHot()
        {

            datTTour qlb = new datTTour();
            qlb.tourHots();
            return View();
        }

       

        public ActionResult TimKiem()
        {

            return View();
        }
        public ActionResult diemdens()
        {


            return View();
        }

        public ActionResult giamgianhieu(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.tourgiamgianhieu();


            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult giamax(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.tourgiamax();


            return View(bb.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult giamin(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.tourgiamin();


            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult testtourssss()
            {

            return View();
            }

        public ActionResult lichtrinh(int? page, string id = "")
        {

            int pageSize = 12;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);


            return View(bb.ToPagedList(pageNumber, pageSize));
        }

        
    }
}