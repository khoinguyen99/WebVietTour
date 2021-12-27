namespace WebsiteRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("NguoiDung")]
    public class admindd
    {
        public int Id { set; get; }
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
}