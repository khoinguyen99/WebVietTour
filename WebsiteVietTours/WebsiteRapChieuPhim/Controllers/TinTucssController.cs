using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Controllers
{
    public class TinTucssController : Controller
    {
        // GET: TinTucs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tinTuc()
        {
            ttTin tt = new ttTin();
            List<TinTuc> lis = tt.tinTucs(string.Empty);

            return View(lis);
        }
       
        public ActionResult chitietTinTuc(string id="")
        {
          
           
            ttTin tt = new ttTin();
            List<TinTuc> lis = tt.tinTucs(id);
            return View(lis.FirstOrDefault());
        }
    }
}