using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Models
{
    public class SanPhamModel
    {
        public decimal ID { get; set; }
        public decimal IDNCC { get; set; }
        public decimal IDLOAISP { get; set; }
        [Required]
        [StringLength(50)]
        public string MASANPHAM { get; set; }

        [StringLength(50)]
        public string LOAISANPHAM { get; set; }
        [Required]
        [StringLength(50)]
        public string NCC { get; set; }
        [StringLength(50)]

        public string NSX { get; set; }
        [StringLength(50)]

        public string TENSANPHAM { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        public decimal GIASANPHAM { get; set; }
      
        public long? SOLUONGTON { get; set; }

        public long? TONTOITHIEU { get; set; }

        public long? LUOTXEM { get; set; }

        [StringLength(250)]
        public string SANPHAMKEMTHEO { get; set; }

        public long? KHUYENMAI { get; set; }

        public bool TRANGTHAI { get; set; }

        [StringLength(250)]
        public string HINHANH { get; set; }

    }
}