using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class khachsanss
    {
        public int id { set; get; }

        public string tenkhachsan { set; get; }
        public string diachi { set; get; }
        public string loaiphong { set; get; }
        public int songuoi { set; get; }


        public string image { set; get; }
        public string gia { set; get; }
        public string rate { set; get; }
        public string desctipt { set; get; }
    }

    public class ksan
    {
        DBConnection db;
        public ksan()
        {
            db = new DBConnection();
        }
        public List<khachsanss> tks(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM KhachSan";
            }
            else
            {
                sql = "SELECT * FROM KhachSan Where id = " + Id;
            }
            List<khachsanss> strList = new List<khachsanss>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            khachsanss dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new khachsanss();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.tenkhachsan = dt.Rows[i]["tenkhachsan"].ToString();
                dtr.diachi = dt.Rows[i]["diachi"].ToString();
                dtr.loaiphong = dt.Rows[i]["loaiphong"].ToString();
                dtr.songuoi = Convert.ToInt32(dt.Rows[i]["songuoi"].ToString());
                dtr.desctipt = dt.Rows[i]["descript"].ToString();
                dtr.image = dt.Rows[i]["image"].ToString();
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.rate = dt.Rows[i]["rate"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }

        public void themphong(DatPhongss dt)
        {
            string sql;
            sql = "insert into DatPhong values(N'"+dt.ten+"',N'"+dt.diachi+"',N'"+dt.email+"','"+dt.dienthoai+"')";
            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }    
    }
}