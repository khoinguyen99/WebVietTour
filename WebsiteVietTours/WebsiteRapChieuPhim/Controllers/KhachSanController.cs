using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;
using PagedList;
using PagedList.Mvc;
namespace WebsiteRapChieuPhim.Controllers
{
    public class KhachSanController : Controller
    {
        // GET: KhachSan
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult khacsans(int? page, string id = "")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ksan xe = new ksan();
            List<khachsanss> xes = xe.tks(id);
            
            return View(xes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult chitietkhachsan(string id = "")
        {
            ksan xe = new ksan();
            List<khachsanss> lis = xe.tks(id);
            return View(lis.FirstOrDefault());
        }


    }
}