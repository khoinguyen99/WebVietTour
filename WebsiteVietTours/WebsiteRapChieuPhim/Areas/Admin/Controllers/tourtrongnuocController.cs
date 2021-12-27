using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Areas.Admin.Controllers
{
    public class tourtrongnuocController : Controller
    {
        // GET: Admin/tourtrongnuoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dstourtnuoc(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult CreateTourTN()
        {

            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTourTN(TourTrongNuoc tt)
        {
            if (ModelState.IsValid)
            {
                tournuoc qlb = new tournuoc();
                qlb.AddDuLieusss(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult EditTourTN(string id = "")
        {

            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTourTN(TourTrongNuoc tt)
        {

            tournuoc qlb = new tournuoc();
            qlb.suaDuLieusss(tt);
            return RedirectToAction("layoutIndex", "Homes");


        }
        public ActionResult DeleteTourTN(string id = "")
        {

            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());


        }

        [HttpPost]

        public ActionResult DeleteTourTN(TourTrongNuoc tt)
        {

            tournuoc qlb = new tournuoc();
            qlb.DeleteDuLieusss(tt);
            return RedirectToAction("layoutIndex", "Homes");



        }

        public ActionResult DetailsTourTN(string id = "")
        {
            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

    }
}