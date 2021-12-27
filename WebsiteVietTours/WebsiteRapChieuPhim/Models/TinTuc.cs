using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace WebsiteRapChieuPhim.Models
{
    public class TinTuc
    {
        public int id { set; get; }
        public string title { set; get; }
        public string content { set; get; }
        public string descrip { set; get; }
        public string image { set; get; }
        

    }

    public class ttTin
    {
        DBConnection db;
        public ttTin()
        {
            db = new DBConnection();
        }

        public List<TinTuc> tinTucs(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM Newss";
            }
            else
            {
                sql = "SELECT * FROM Newss Where id = " + Id;
            }
            List<TinTuc> strList = new List<TinTuc>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            TinTuc tt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tt = new TinTuc();
                tt.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                tt.title = dt.Rows[i]["title"].ToString();
                tt.content = dt.Rows[i]["content"].ToString();
                tt.descrip = dt.Rows[i]["descriptions"].ToString();
                
                tt.image = dt.Rows[i]["photo"].ToString();

                strList.Add(tt);

            }
            return strList;

        }

        public void adddulieu(TinTuc tt)
        {
            string sql;
            sql = "insert into Newss(title,content,descriptions,photo)values(N'" + tt.title + "',N'" + tt.content + "',N'" + tt.descrip +"',N'" + tt.image + "')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }

        public void suadulieu(TinTuc tt)
        {
            string sql;
            sql = "UPDATE Newss SET title=N'" + tt.title + "',content=N'" + tt.content + "',descriptions=N'" + tt.descrip + "',photo=N'" + tt.image + "' WHERE id = " + tt.id;

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void deletedulieu(TinTuc tt)
        {
            string sql;
            sql = "delete Newss where id='" + tt.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
}