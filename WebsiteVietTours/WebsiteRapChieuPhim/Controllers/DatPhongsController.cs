using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRapChieuPhim.Models;

namespace WebsiteRapChieuPhim.Controllers
{
    public class DatPhongsController : Controller
    {
        // GET: DatPhongs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePhong(DatPhongss tt)
        {
            string ten = Request["ten"];
            string diachi = Request["diachi"];
            string email = Request["email"];
            string dienthoai = Request["phones"];
            string tenks = Request["tenkhachsan"];
            if (ten == "" || diachi == "" || email == "" || dienthoai == "" || tenks == "")
            {
                ViewBag.error = "Sai dữ liệu";
            }
            else
            {
                ViewBag.tens = ten;
                ViewBag.diachis = diachi;
                ViewBag.emails = email;
                ViewBag.phones = dienthoai;
                ViewBag.ks = tenks;
                dphong dp = new dphong();
                 
                dp.insertphong(tt);
                
                Response.Write("<script>alert('Đặt phòng thành công !!!');</script>");
                return View();

            }

            
            return RedirectToAction("khacsans","KhachSan");
        }

        




    }
}