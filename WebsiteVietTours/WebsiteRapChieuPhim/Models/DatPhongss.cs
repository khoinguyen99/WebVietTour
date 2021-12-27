using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class DatPhongss
    {
        public int id { set; get; }
        [Display(Name = "Tên")]
        public string ten { set; get; }
        [Display(Name = "Địa chỉ")]
        public string diachi { set; get; }
        [Display(Name = "Email")]
        public string email { set; get; }
        [Display(Name = "Phone")]
        public string dienthoai { set; get; }

        public string tenkhachsan { set; get; }
    }

    public class dphong
    {
        DBConnection db;
       public dphong()
        {
            db = new DBConnection();
        }

        public void insertphong(DatPhongss dp)
        {
            string sql;
            sql = string.Format("INSERT INTO DatPhong VALUES(N'"+dp.ten+"',N'"+dp.diachi+"',N'"+dp.email+"',N'"+dp.dienthoai+"',N'"+dp.tenkhachsan+"')");

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
        public void updatephong(DatPhongss dp)
        {
            string sql;
            sql = string.Format("UPDATE DatPhong  SET  ten =N'"+dp.ten+"',diachi = N'"+dp.diachi+"',email = N'"+dp.email+"',dienthoai = N'"+dp.dienthoai+"' where id = '"+dp.id+"'");

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
}