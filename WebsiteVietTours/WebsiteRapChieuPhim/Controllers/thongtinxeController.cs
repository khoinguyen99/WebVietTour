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
    public class thongtinxeController : Controller
    {
        // GET: thongtinxe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tXe(int? page,string id="")
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ttXe xe = new ttXe();
            List<NewsXe> xes = xe.tinxe(id);
            return View(xes.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult chitietXe(string id = "")
        {


            ttXe xe = new ttXe();
            List<NewsXe> lis = xe.tinxe(id);
            return View(lis.FirstOrDefault());
        }
    }
}