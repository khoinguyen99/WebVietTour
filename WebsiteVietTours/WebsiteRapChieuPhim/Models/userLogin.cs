using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteRapChieuPhim.Models
{
   
    [Serializable]
    public class userLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
    }
}