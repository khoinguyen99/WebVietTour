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
    public class tournnController : Controller
    {
        // GET: Admin/tournn
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult dstourtnuocs(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult CreateTourTNN()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTourTNN(TourNuocNgoai tt)
        {
            if (ModelState.IsValid)
            {
                tournuocngoai qlb = new tournuocngoai();
                qlb.AddDuLieussss(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult EditTourTNN(string id = "")
        {

            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTourTNN(TourNuocNgoai tt)
        {

            tournuocngoai qlb = new tournuocngoai();
            qlb.suaDuLieussss(tt);
            return RedirectToAction("layoutIndex", "Homes");


        }
        public ActionResult DeleteTourTNN(string id = "")
        {

            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());


        }

        [HttpPost]

        public ActionResult DeleteTourTNN(TourNuocNgoai tt)
        {

            tournuocngoai qlb = new tournuocngoai();
            qlb.DeleteDuLieussss(tt);
            return RedirectToAction("layoutIndex", "Homes");



        }

        public ActionResult DetailsTourTNN(string id = "")
        {
            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }
    }
}