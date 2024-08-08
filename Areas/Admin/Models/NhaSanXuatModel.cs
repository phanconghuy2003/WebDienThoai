using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class NhaSanXuatModel
    {
        [Key]
        public int ID_NSX { get; set; }

        [StringLength(10)]
        public string MANSX { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_NSX { get; set; }

        [StringLength(11)]
        public string SDT_NSX { get; set; }

        [StringLength(250)]
        public string MOTA_NSX { get; set; }

        [StringLength(300)]
        public string DIACHI_NSX { get; set; }

        [StringLength(250)]
        public string GHICHU_NSX { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}