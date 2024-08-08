using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class TaiKhoanModel
    {
        public decimal ID { get; set; }

        [StringLength(50)]
        public string TENTAIKHOAN { get; set; }

        public string LOAITAIKHOAN { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string HOTEN { get; set; }

        [StringLength(250)]
        public string EMAIL_TK { get; set; }

        [StringLength(300)]
        public string DIACHI_TK { get; set; }


 

        [StringLength(250)]
        public string GHICHU_TK { get; set; }
        public bool STATUS { get; set; }
    }
}