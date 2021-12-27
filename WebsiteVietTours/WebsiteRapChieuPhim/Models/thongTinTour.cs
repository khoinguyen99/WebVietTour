using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
    public class thongTinTour
    {
        
        public int id { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string hoten { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string diachi { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập email")]
       
        [Display(Name = "Email")]

        public string email { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [Display(Name = "Điện thoại")]
        public string dienthoai { set; get; }
        [Required(ErrorMessage = "Bạn chưa nhập ngày khởi hành")]
        [Display(Name = "Ngày khởi hành")]

        public string khoihanhngay { set; get; }
      
        [Display(Name = "Tổng số khách ")]
        [Range(0, 20, ErrorMessage = "{0} tối đa {2} người")]
        public string tongsokhach { set; get; }      
        [Display(Name = "Note")]
        public string note { set; get; }
        [Display(Name = "Tên Tour")]
        public string tentours { set; get; }

        public Boolean tourdadi { set; get; }

       


    }

    public class AddThongTin
    {
        datTTour dtt = new datTTour();
        DBConnection db;
            public AddThongTin()
        {
            db = new DBConnection();
        }

        public List<thongTinTour> tttour(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM orderTour";
            }
            else
            {
                sql = "SELECT * FROM orderTour Where id = " + Id;
            }
            List<thongTinTour> strList = new List<thongTinTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            thongTinTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new thongTinTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.hoten = dt.Rows[i]["hoten"].ToString();
                dtr.diachi = dt.Rows[i]["diachi"].ToString();
                dtr.email = dt.Rows[i]["email"].ToString();

                dtr.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();
                dtr.tongsokhach = dt.Rows[i]["tongsokhach"].ToString();
                dtr.note = dt.Rows[i]["note"].ToString();
                dtr.tentours= dt.Rows[i]["tentour"].ToString();
                
                dtr.tourdadi = Convert.ToBoolean(dt.Rows[i]["tourdadi"].ToString());
                strList.Add(dtr);

            }
            return strList;
        }

        public void addDulieu(thongTinTour tt)
        {

            string sql;
            sql = "INSERT INTO orderTour(hoten,diachi,email,dienthoai,khoiHangNgay,tongsokhach,note,tentour,tourdadi)VALUES(N'" + tt.hoten + "',N'" + tt.diachi + "',N'" + tt.email + "',N'" + tt.dienthoai + "',N'" + tt.khoihanhngay + "',N'" + tt.tongsokhach + "',N'" + tt.note + "',N'" + tt.tentours.Trim() +"',N'"+tt.tourdadi+"')";


            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
           
        }

        public void suadulieu(thongTinTour tt)
        {
            string sql;
            sql = "UPDATE orderTour SET hoten=N'" + tt.hoten + "',diachi=N'" + tt.diachi + "',email=N'" + tt.email + "',dienthoai=N'" + tt.dienthoai + "',khoiHangNgay=N'" + tt.khoihanhngay + "',tongsokhach=N'" + tt.tongsokhach + "',note=N'" + tt.note + "',tentour=N'" + tt.tentours + "',tourdadi=N'"+tt.tourdadi+"' WHERE id = " + tt.id;

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public void deletedulieu(thongTinTour tt)
        {
            string sql;
            sql = "delete orderTour where id='" + tt.id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
        public void deletedulieus(string id)
        {
            string sql;
            sql = "delete orderTour where id='" + id + "'";

            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
        public void emailjoin(string emaill)
        {
            string sql;
            sql = string.Format("SELECT  orderTour.hoten,orderTour.diachi,NguoiDung.email,orderTour.dienthoai,orderTour.khoiHangNgay,orderTour.tongsokhach,orderTour.note FROM orderTour INNER JOIN NguoiDung ON  orderTour.email = NguoiDung.email where NguoiDung.email = N'{0}'", emaill);
            SqlConnection conn = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
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
        public DataTable selectToemail(string emaill,string tentour)
        {

            return getlogin(string.Format("SELECT  orderTour.hoten,orderTour.diachi,NguoiDung.email,Tour.tentour,orderTour.dienthoai,orderTour.khoiHangNgay,orderTour.tongsokhach,orderTour.note FROM orderTour INNER JOIN NguoiDung ON  orderTour.email = NguoiDung.email where NguoiDung.email = N'{0}'", emaill));
        }

        public int checkemaill(string emaill,string tentour)
        {
            int id = -1;
            DataTable dt = selectToemail(emaill,tentour);
            if (dt.Rows.Count > 0)
            {

                id = int.Parse(dt.Rows[0][0].ToString());

            }
            return id;


            
        }

        public List<thongTinTour> checkkemail(string emaill)
        {
           
                string sql;


                sql = string.Format("SELECT Tour.id, orderTour.hoten,orderTour.diachi,NguoiDung.email,orderTour.dienthoai,orderTour.khoiHangNgay,orderTour.tongsokhach,orderTour.note,Tour.tentour as TenTour " +
                      "FROM ((orderTour" +
                      " INNER JOIN NguoiDung ON  orderTour.email = NguoiDung.email)" +
                      " INNER JOIN Tour ON  orderTour.tentour = Tour.tentour) where NguoiDung.email = N'{0}'", emaill);
                //Sqll = string.Format("SELECT orderTour.hoten,orderTour.diachi,orderTour.dienthoai,orderTour.khoiHangNgay,orderTour.tongsokhach,orderTour.note,NguoiDung.email,Tour.tenTour AS TenTourFROM((orderTourINNER JOIN NguoiDung ON orderTour.email = NguoiDung.email) INNER JOIN Tour ON  orderTour.tentour = Tour.tenTour) where NguoiDung.email = N'ddd' "); 

                List<thongTinTour> strList = new List<thongTinTour>();
                SqlConnection sqlcon = db.getConnection();
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                sqlcon.Open();
                da.Fill(dt);
                da.Dispose();
                sqlcon.Close();
                thongTinTour dtr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtr = new thongTinTour();
                    dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    dtr.hoten = dt.Rows[i]["hoten"].ToString();
                    dtr.diachi = dt.Rows[i]["diachi"].ToString();
                    dtr.email = dt.Rows[i]["email"].ToString();

                    dtr.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                    dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();
                    dtr.tongsokhach = dt.Rows[i]["tongsokhach"].ToString();
                    dtr.note = dt.Rows[i]["note"].ToString();
                    dtr.tentours = dt.Rows[i]["tentour"].ToString();
                    strList.Add(dtr);

                }
                return strList;
            
        }

        

            public List<thongTinTour> checkkemailf()
        {

            string sql;


            sql = string.Format("SELECT Tour.id, orderTour.hoten, orderTour.diachi, orderTour.dienthoai, orderTour.khoiHangNgay, orderTour.tongsokhach, orderTour.note, Tour.tentour as TenTour"+
                                "FROM orderTour"+
                                "INNER JOIN Tour ON orderTour.tentour = Tour.tentour");
            //Sqll = string.Format("SELECT orderTour.hoten,orderTour.diachi,orderTour.dienthoai,orderTour.khoiHangNgay,orderTour.tongsokhach,orderTour.note,NguoiDung.email,Tour.tenTour AS TenTourFROM((orderTourINNER JOIN NguoiDung ON orderTour.email = NguoiDung.email) INNER JOIN Tour ON  orderTour.tentour = Tour.tenTour) where NguoiDung.email = N'ddd' "); 

            List<thongTinTour> strList = new List<thongTinTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            thongTinTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtr = new thongTinTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.hoten = dt.Rows[i]["hoten"].ToString();
                dtr.diachi = dt.Rows[i]["diachi"].ToString();
                dtr.email = dt.Rows[i]["email"].ToString();

                dtr.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();
                dtr.tongsokhach = dt.Rows[i]["tongsokhach"].ToString();
                dtr.note = dt.Rows[i]["note"].ToString();
                dtr.tentours = dt.Rows[i]["tentour"].ToString();
                strList.Add(dtr);

            }
            return strList;

        }
        public List<thongTinTour> tourdadi(string key)
        {
            string sql;
            sql = "SELECT * FROM orderTour WHERE tourdadi = '"+key+"'";
            List<thongTinTour> strList = new List<thongTinTour>();
            SqlConnection sqlcon = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            da.Fill(dt);
            da.Dispose();
            sqlcon.Close();
            thongTinTour dtr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                dtr = new thongTinTour();
                dtr.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                dtr.hoten = dt.Rows[i]["hoten"].ToString();
                dtr.diachi = dt.Rows[i]["diachi"].ToString();
                dtr.email = dt.Rows[i]["email"].ToString();

                dtr.dienthoai = dt.Rows[i]["dienthoai"].ToString();
                dtr.khoihanhngay = dt.Rows[i]["khoiHangNgay"].ToString();
                dtr.tongsokhach = dt.Rows[i]["tongsokhach"].ToString();
                dtr.note = dt.Rows[i]["note"].ToString();
                dtr.tentours = dt.Rows[i]["tentour"].ToString();
                dtr.tourdadi = Convert.ToBoolean(dt.Rows[i]["tourdadi"].ToString());
                strList.Add(dtr);

            }
            return strList;
        }

       







    }
}