using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Controllers
{
    public class TourNuocNgoaiController : Controller
    {
        // GET: TourNuocNgoai
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tournuocngoai(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult detailTNuocNgoai(string id = "")
        {

            tournuocngoai qlb = new tournuocngoai();
            List<TourNuocNgoai> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }

    }
}