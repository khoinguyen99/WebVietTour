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
    public class DsTourController : Controller
    {
        // GET: Admin/DsTour
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult dstour(int? page, string id = "")
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult CreateTourKM()
        {

            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTourKM(DatTour tt)
        {
            if (ModelState.IsValid)
            {
                datTTour qlb = new datTTour();
                qlb.AddDuLieus(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }
        [ValidateInput(false)]
        public ActionResult EditTourKM(string id = "")
        {

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTourKM(DatTour tt)
        {

            datTTour qlb = new datTTour();
            qlb.suaDuLieus(tt);
            return RedirectToAction("layoutIndex", "Homes");


        }
        public ActionResult DeleteTourKM(string id = "")
        {

            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());


        }

        [HttpPost]

        public ActionResult DeleteTourKM(DatTour tt)
        {

            datTTour qlb = new datTTour();
            qlb.DeleteDuLieus(tt);
            return RedirectToAction("layoutIndex", "Homes");



        }

        public ActionResult DetailsTourKM(string id = "")
        {
            datTTour qlb = new datTTour();
            List<DatTour> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

    

    }
}