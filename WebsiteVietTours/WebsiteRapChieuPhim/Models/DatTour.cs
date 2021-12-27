using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class DatTour
    {

        public int id { set; get; }


        public string khoihanhtu { set; get; }

       
        public string thoigian { set; get; }
        public string khoihanhngay { set; get; }
        
        public string gioithieutour { set; get; }

        public string thumnail { set; get; }

      
        public string chuongtrinhtour { set; get; }
     
        public string khuyenmai { set; get; }

        public int diemdenid{ set; get; }

        public string gia { set; get; }
         
        public string tentour { set; get; }
        public int soluotxem { set; get; }
    }


    public class datTTour
    {
        DBConnection db;
        public datTTour()
        {
            db = new DBConnection();
        }
        public List<DatTour> dtour(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM Tour";
            }
            else
            {
                sql = "SELECT * FROM Tour Where id = " + Id;
            }
            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();
              
                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                dtr.soluotxem = Convert.ToInt32(dt.Rows[i]["soluotxem"].ToString());
                strList.Add(dtr);

            }
            return strList;





        }


        public void AddDuLieus(DatTour tours)
        {
            string sql;
            sql = "INSERT INTO Tour(khoiHanhTu,thoiGian,khoiHangNgay,gioithieuTuor,thumbnail,chuongtrinhtour,khuyenmai,diemdenid,gia,tenTour,soluotxem)VALUES(N'" + tours.khoihanhtu + "',N'" + tours.thoigian + "',N'" + tours.khoihanhngay + "',N'" + tours.gioithieutour + "',N'" + tours.thumnail + "',N'" + tours.chuongtrinhtour + "',N'" + tours.khuyenmai + "','" + tours.diemdenid + "',N'" + tours.gia + "',N'" + tours.tentour+ "','" + 0 + "')";
            

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }

        public void suaDuLieus(DatTour tours)
        {
            string sql;
            sql = "UPDATE Tour SET khoiHanhTu=N'" + tours.khoihanhtu + "',thoiGian=N'" + tours.thoigian + "',khoiHangNgay=N'" + tours.khoihanhngay + "',gioiThieuTuor=N'" + tours.gioithieutour + "',thumbnail=N'" + tours.thumnail + "',chuongtrinhtour = N'" + tours.chuongtrinhtour + "',khuyenmai=N'" + tours.khuyenmai + "',diemdenid='" + tours.diemdenid + "',gia = N'" + tours.gia + "',tenTour=N'" + tours.tentour + "',soluotxem='" + 0 + "' WHERE id='" + tours.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void DeleteDuLieus(DatTour tours)
        {
            string sql;
            sql = "DELETE Tour WHERE id='" + tours.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public List<DatTour> dtimkiemtour(string key)
        {
            string sql;
            sql = "select id,khoiHanhTu,thoiGian,khoiHangNgay,gioiThieuTuor,thumbnail,chuongtrinhtour,khuyenmai,diemdenid,gia,tenTour "+ 
                    "from Tour "+
                    "where tenTour  like N'%"+key+"%'";
            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;



        }

        public List<DatTour> ddtimkiem(string key)
        {
            string sql;
            sql = "select id,khoiHanhTu,thoiGian,khoiHangNgay,gioiThieuTuor,thumbnail,chuongtrinhtour,khuyenmai,diemdenid,gia,tenTour " +
                    "from Tour " +
                    "where tenTour  like N'%" + key + "%'";
            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;



        }
        public void tourHot(string id)
        {

            string sql;
            sql = string.Format("Update Tour Set soluotxem = soluotxem + 1 where id = " + id + "");

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();



        }

        public List<DatTour> tourHots()
        {
            string sql;
            sql = string.Format("SELECT TOP 10 * FROM Tour ORDER BY soluotxem DESC");

            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }


        public List<DatTour> tourgiamgianhieu()
        {
            string sql;
            sql = string.Format("select * from Tour order by CONVERT(int,khuyenmai) DESC");

            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }
        public List<DatTour> tourgiamax()
        {
            string sql;
            sql = string.Format("select * from Tour order by CONVERT(int,gia) DESC");

            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }
        public List<DatTour> tourgiamin()
        {

            string sql;
            sql = string.Format("select * from Tour order by CONVERT(int,gia)");

            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }


        public List<DatTour> newtourss()
        {
            string sql;
            sql = string.Format("SELECT TOP 20 * FROM Tour ORDER BY id DESC");

            List<DatTour> strList = new List<DatTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            DatTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new DatTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.khoihanhtu = dt.Rows[i]["khoiHanhTu"].ToString();
                dtr.thoigian = dt.Rows[i]["thoiGian"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();

                dtr.gioithieutour = dt.Rows[i]["gioithieuTuor"].ToString();
                dtr.thumnail = dt.Rows[i]["thumbnail"].ToString();
                dtr.chuongtrinhtour = dt.Rows[i]["chuongtrinhtour"].ToString();
                dtr.khuyenmai = dt.Rows[i]["khuyenmai"].ToString();
                dtr.diemdenid = Convert.ToInt32(dt.Rows[i]["diemdenid"].ToString());
                dtr.gia = dt.Rows[i]["gia"].ToString();
                dtr.tentour = dt.Rows[i]["tenTour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }
    }
}