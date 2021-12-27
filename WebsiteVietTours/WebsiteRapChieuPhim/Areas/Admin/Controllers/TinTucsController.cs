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
    public class TinTucsController : Controller
    {
        // GET: Admin/TinTucs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult qlTinTuc(int? page,string id="")
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ttTin tt = new ttTin();
            List<TinTuc> tts = tt.tinTucs(id);
            return View(tts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CreateTinTuc()
        {

            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTinTuc(TinTuc tt)
        {
            if (ModelState.IsValid)
            {
                ttTin dn = new ttTin();
                dn.adddulieu(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }
        [ValidateInput(false)]
        public ActionResult EditTinTuc(string id = "")
        {

            ttTin dn = new ttTin();
            List<TinTuc> hh = dn.tinTucs(id);
            return View(hh.FirstOrDefault());
        }
        [HttpPost]
        [ValidateInput(false)]
        
        public ActionResult EditTinTuc(TinTuc tt)
        {

            ttTin dn = new ttTin();
            dn.suadulieu(tt);
            return RedirectToAction("layoutIndex", "Homes");


        }
        public ActionResult DeleteTinTuc(string id = "")
        {

            ttTin dn = new ttTin();
            List<TinTuc> hh = dn.tinTucs(id);
            return View(hh.FirstOrDefault());


        }
        [HttpPost]

        public ActionResult DeleteTinTuc(TinTuc tt)
        {

            ttTin dn = new ttTin();
            dn.deletedulieu(tt);
            return RedirectToAction("layoutIndex", "Homes");



        }

        public ActionResult DetailsTinTuc(string id = "")
        {
            ttTin dn = new ttTin();
            List<TinTuc> hh = dn.tinTucs(id);
            return View(hh.FirstOrDefault());
        }

    }
}