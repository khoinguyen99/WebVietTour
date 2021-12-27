using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class NewsXe
    {
         public int id { set; get; }

         public string loaixe { set; get; }
        public string tuyenxe { set; get; }
        public string dongia { set; get; }
        public string image { set; get; }

        public string rage { set; get; }

        public string desctipt { set; get; }
    }

    public class ttXe
    {
        DBConnection db;
        public ttXe()
        {
            db = new DBConnection();
        }
        public List<NewsXe> tinxe(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM ThongTinXe";
            }
            else
            {
                sql = "SELECT * FROM ThongTinXe Where id = " + Id;
            }
            List<NewsXe> strList = new List<NewsXe>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            NewsXe dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new NewsXe();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.loaixe = dt.Rows[i]["loaixe"].ToString();
                dtr.tuyenxe = dt.Rows[i]["tuyenxe"].ToString();
                dtr.dongia = dt.Rows[i]["dongia"].ToString();
                dtr.image = dt.Rows[i]["image"].ToString();
                dtr.rage = dt.Rows[i]["rate"].ToString();
                dtr.desctipt = dt.Rows[i]["descript"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }

        public void adddulieus(NewsXe tt)
        {
            string sql;
            sql = "insert into ThongTinXe(loaixe,tuyenxe,dongia,image,rate,descript)values(N'" + tt.loaixe+ "',N'" + tt.tuyenxe + "',N'" + tt.dongia+ "',N'" + tt.image + "',N'" + tt.rage+"',N'" + tt.desctipt+"')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }

        public void suadulieus(NewsXe tt)
        {
            string sql;
            sql = "UPDATE ThongTinXe SET loaixe=N'" + tt.loaixe+ "',tuyenxe=N'" + tt.tuyenxe + "',dongia=N'" + tt.dongia + "',image=N'" + tt.image + "',rate=N'" + tt.rage + "',descript=N'" + tt.desctipt + "' WHERE id = " + tt.id;

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void deletedulieus(NewsXe tt)
        {
            string sql;
            sql = "delete ThongTinXe where id='" + tt.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

    }
}