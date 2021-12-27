using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class TourTrongNuoc
    {
        public int id { set; get; }


        public string khoihanhtu { set; get; }

        public string thoigian { set; get; }
        public string khoihanhngay { set; get; }

        public string gioithieutour { set; get; }

        public string thumnail { set; get; }

        public string chuongtrinhtour { set; get; }

        public string khuyenmai { set; get; }

        public int diemdenid { set; get; }

        public string gia { set; get; }

        public string tentour { set; get; }
    }
    public class tournuoc
    {
        DBConnection db;
        public tournuoc()
        {
            db = new DBConnection();
        }
        public List<TourTrongNuoc> dtour(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM TTrongNuoc";
            }
            else
            {
                sql = "SELECT * FROM TTrongNuoc Where id = " + Id;
            }
            List<TourTrongNuoc> strList = new List<TourTrongNuoc>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            TourTrongNuoc dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new TourTrongNuoc();
                dtr.id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoihanhtu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoigian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoihangngay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieutour"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tentour"].ToString();
                strList.Add(dtr);

            }
            return strList;
        }


        public void AddDuLieusss(TourTrongNuoc tn)
        {
            string sql;
            sql = "INSERT INTO TTrongNuoc(khoiHanhTu,thoiGian,khoiHangNgay,gioithieutour,thumbnail,chuongtrinhtour,khuyenmai,diemdenid,gia,tenTour)VALUES(N'" + tn.khoihanhtu + "',N'" + tn.thoigian + "',N'" + tn.khoihanhngay + "',N'" + tn.gioithieutour + "',N'" + tn.thumnail + "',N'" + tn.chuongtrinhtour + "',N'" + tn.khuyenmai + "','" + tn.diemdenid + "',N'" + tn.gia + "',N'" + tn.tentour + "')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }

        public void suaDuLieusss(TourTrongNuoc tn)
        {
            string sql;
            sql = "UPDATE TTrongNuoc SET khoiHanhTu=N'" + tn.khoihanhtu + "',thoiGian=N'" + tn.thoigian + "',khoiHangNgay=N'" + tn.khoihanhngay + "',gioiThieutour=N'" + tn.gioithieutour + "',thumbnail=N'" + tn.thumnail + "',chuongtrinhtour = N'" + tn.chuongtrinhtour + "',khuyenmai=N'" + tn.khuyenmai + "',diemdenid='" + tn.diemdenid + "',gia = N'" + tn.gia + "',tenTour=N'" + tn.tentour + "' WHERE id='" + tn.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void DeleteDuLieusss(TourTrongNuoc tn)
        {
            string sql;
            sql = "DELETE TTrongNuoc WHERE id='" + tn.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }




    }
}
