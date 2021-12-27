using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace WebsiteRapChieuPhim.Models
{
  
    public class admin
    {
       
        public int Id { set; get;}
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
       
        public string name { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập Username")]
        public string username { set; get; }
         [Required(ErrorMessage = "Bạn chưa nhập password")]
        
        public string password { set; get; }
        public int status { set; get; }
        public Boolean isAdmin { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        public string email { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string phone { set; get; }

      

    }


    public class dangNhap 
    {
        DBConnection db;
        public dangNhap()
        {
            db = new DBConnection();
        }

        public List<admin> logins(string id)
        {
            string sql;
            if (string.IsNullOrEmpty(id))
            {
                sql = "SELECT * FROM NguoiDung";
            }
            else
            {
                sql = "SELECT * FROM NguoiDung Where ID = " + id;
            }
            List<admin> strList = new List<admin>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            admin dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new admin();
                dtr.Id = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                dtr.name = dt.Rows[i]["name"].ToString();
                dtr.username = dt.Rows[i]["username"].ToString();
                dtr.password = dt.Rows[i]["password"].ToString();

                dtr.status = Convert.ToInt32(dt.Rows[i]["status"].ToString());
                dtr.isAdmin = Convert.ToBoolean(dt.Rows[i]["isAdmin"].ToString());
                dtr.email = dt.Rows[i]["email"].ToString();
                dtr.phone = dt.Rows[i]["phone"].ToString();
                strList.Add(dtr);

            }
            return strList;
        }
          
        public DataTable checkEmail(string user)
        {
            return getlogin(string.Format("select * from [NguoiDung] where username=N'{0}'",user));

        }
        public DataTable checkUser(string emai)
        {
            return getlogin(string.Format("select * from [NguoiDung] where email=N'{0}'", emai));

        }
        public int checkEs(string emai)
        {
            int emails = -1;
            DataTable dt = checkUser(emai);
            if (dt.Rows.Count > 0)
            {

                emails = int.Parse(dt.Rows[0][0].ToString());

            }

            return emails;
        }
        public int checkE(string user)
        {
            int id = -1;
            DataTable dt = checkEmail(user);
            if (dt.Rows.Count > 0)
            {

                id = int.Parse(dt.Rows[0][0].ToString());

            }

            return id;
        }

      
        public DataTable getlogin(string sql)
        {

            

            DataTable dt = new DataTable();
            SqlConnection conn = db.getConnection();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            return dt;

        }
       //Fix EMail
        public DataTable selectTokLogin(string uname, string pass)
        {
           
            return getlogin(string.Format("SELECT * FROM [NguoiDung] where email=N'{0}' and password=N'{1}'", uname, pass));
        }

        public int checklogin(string user,string pass)
        {
            int id = -1;         
            DataTable dt = selectTokLogin(user, pass);
            if (dt.Rows.Count > 0)
            {

                id = int.Parse(dt.Rows[0][0].ToString());

            }
            return id;
        }

        public DataTable isAdmin(int id)
        {
            return getlogin("select isAdmin from [NguoiDung] where ID= " + id);
        }

        public bool IsAdmin(int id)
        {
            if (id < 1)
            {
                id = 1;
            }
            DataTable dt = isAdmin(id);

            return bool.Parse(dt.Rows[0][0].ToString());
        }
        public static void Alert(System.Web.UI.Page page, String eMessage)
        {
            String sScript;
            sScript = "<script type =text/javascript> alert('" + eMessage + "');</script>";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", sScript);
        }

        //Thêm Sửa Xóa Chi Tiết Quản Lý Tài Khoản

        public void AddDuLieu(admin tt)
        {
            string sql;
            sql = "INSERT INTO NguoiDung(name, username, password, status, isAdmin, email, phone)VALUES(N'" + tt.name + "', N'" + tt.username + "', N'" + tt.password + "','" + "" + "','" + "" + "', N'" + tt.email + "', N'" + tt.phone + "')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }
        public void addDuLieu(admin tt)
        {
            string sql;
            sql = "INSERT INTO NguoiDung(name, username, password, status, isAdmin, email, phone)VALUES(N'" + tt.name + "', N'" + tt.username + "', N'" + tt.password + "','" + tt.status + "','" + tt.isAdmin + "', N'" + tt.email + "', N'" + tt.phone + "')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }

        public void suaDuLieu(admin tt)
        {
            string sql;
            sql = "UPDATE NguoiDung SET name=N'" + tt.name + "',username=N'" + tt.username + "',password=N'" + tt.password+"',status='" + tt.status+ "',isAdmin='" + tt.isAdmin + "',email=N'" + tt.email + "',phone=N'" + tt.phone + "' WHERE Id='" + tt.Id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void DeleteDuLieu(admin tt)
        {
            string sql;
            sql = "DELETE NguoiDung WHERE Id='" + tt.Id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }


    }



}