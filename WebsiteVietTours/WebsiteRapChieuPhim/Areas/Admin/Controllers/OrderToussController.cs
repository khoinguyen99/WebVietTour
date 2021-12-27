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
    public class OrderToussController : Controller
    {
        // GET: Admin/OrderTouss
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dsodertour(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            AddThongTin qlb = new AddThongTin();
            List<thongTinTour> bb = qlb.tttour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult CreateOderTours()
        {

            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateOderTours(thongTinTour tt)
        {
            if (ModelState.IsValid)
            {
                AddThongTin qlb = new AddThongTin();
                qlb.addDulieu(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }
        [ValidateInput(false)]
        public ActionResult EditOderTours(string id = "")
        {

            AddThongTin qlb = new AddThongTin();
            List<thongTinTour> bb = qlb.tttour(id);
            return View(bb.FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditOderTours(thongTinTour tt)
        {

            AddThongTin qlb = new AddThongTin();
            qlb.suadulieu(tt);
            return RedirectToAction("dsodertour", "OrderTouss");


        }
        public ActionResult DeleteOderTours(string id = "")
        {

            AddThongTin qlb = new AddThongTin();
            List<thongTinTour> bb = qlb.tttour(id);
            return View(bb.FirstOrDefault());


        }

        [HttpPost]

        public ActionResult DeleteOderTours(thongTinTour tt)
        {

            AddThongTin qlb = new AddThongTin();
            qlb.deletedulieu(tt);
            return RedirectToAction("dsodertour", "OrderTouss");



        }

        public ActionResult DetailsOderTours(string id = "")
        {
            AddThongTin qlb = new AddThongTin();
            List<thongTinTour> bb = qlb.tttour(id);
            return View(bb.FirstOrDefault());
        }

        public ActionResult tourdadis()
        {
            return View();
        }    

    }
}