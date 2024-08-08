using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class DetailNhapModel
    {
        public long id { get; set; }
        public long idNCC { get; set; }
        public long idNhap { get; set; }
        public long idProduct { get; set; }
        public long? SoLuong { get; set; }
        public decimal? Price { get; set; }
    }
}