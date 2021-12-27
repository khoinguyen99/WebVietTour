using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Controllers
{
    public class TourTrongNuocsController : Controller
    {
        // GET: TourTrongNuocs
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult tournuoc(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);

            return View(bb.ToPagedList(pageNumber, pageSize));
            
        }
      
        public ActionResult detailTTNuoc(string id="")
        {

            tournuoc qlb = new tournuoc();
            List<TourTrongNuoc> bb = qlb.dtour(id);
            return View(bb.FirstOrDefault());
        }    
    }
}