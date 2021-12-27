using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;
using PagedList;
using PagedList.Mvc;
namespace WebsiteRapChieuPhim.Areas.Admin.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        // GET: Admin/QLTaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult qlTaiKhoan(int? page,string id="")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            dangNhap dn = new dangNhap();
            List<admin> ad = dn.logins(id);
            return View(ad.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(admin tt)
        {
            if (ModelState.IsValid)
            {
                dangNhap dn = new dangNhap();
                dn.addDuLieu(tt);
                return RedirectToAction("qlTaiKhoan", "QLTaiKhoan");

            }
            return View();
        }
        public ActionResult Edit(string id = "")
        {

            dangNhap dn = new dangNhap();
            List<admin> hh = dn.logins(id);
            return View(hh.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(admin tt)
        {

            dangNhap dn = new dangNhap();
            dn.suaDuLieu(tt);
            return RedirectToAction("qlTaiKhoan", "QLTaiKhoan");


        }
        public ActionResult Delete(string id = "")
        {

            dangNhap dn = new dangNhap();
            List<admin> hh = dn.logins(id);
            return View(hh.FirstOrDefault());


        }
        [HttpPost]

        public ActionResult Delete(admin tt)
        {
           
                dangNhap dn = new dangNhap();
                dn.DeleteDuLieu(tt);
                return RedirectToAction("qlTaiKhoan", "QLTaiKhoan");
            
           

        }

        public ActionResult Details(string id = "")
        {
            dangNhap dn = new dangNhap();
            List<admin> hh =dn.logins(id);
            return View(hh.FirstOrDefault());
        }
    }
}