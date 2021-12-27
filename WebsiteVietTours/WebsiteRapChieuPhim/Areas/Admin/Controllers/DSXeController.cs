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
    public class DSXeController : Controller
    {
        // GET: Admin/DSXe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tXes(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ttXe xe = new ttXe();
            List<NewsXe> xes = xe.tinxe(id);
            return View(xes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CreateTourTNNN()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTourTNNN(NewsXe tt)
        {
            if (ModelState.IsValid)
            {
                ttXe xe = new ttXe();
                xe.adddulieus(tt);
                return RedirectToAction("layoutIndex", "Homes");

            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult EditTourTNNN(string id = "")
        {

            ttXe xe = new ttXe();
            List<NewsXe> bb = xe.tinxe(id);
            return View(bb.FirstOrDefault());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTourTNNN(NewsXe tt)
        {

            ttXe xe = new ttXe();
            xe.suadulieus(tt);
            return RedirectToAction("layoutIndex", "Homes");


        }
        public ActionResult DeleteTourTNNN(string id = "")
        {

            ttXe xe = new ttXe();
            List<NewsXe> bb = xe.tinxe(id);
            return View(bb.FirstOrDefault());


        }

        [HttpPost]

        public ActionResult DeleteTourTNNN(NewsXe tt)
        {

            ttXe xe = new ttXe();
            xe.deletedulieus(tt);
            return RedirectToAction("layoutIndex", "Homes");



        }

        public ActionResult DetailsTourTNNN(string id = "")
        {
            ttXe xe = new ttXe();
            List<NewsXe> bb = xe.tinxe(id);
            return View(bb.FirstOrDefault());
        }
    }
}