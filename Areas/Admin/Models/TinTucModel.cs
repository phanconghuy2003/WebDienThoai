using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Models
{
    public class TinTucModel
    {
        public long TINTUC_ID { get; set; }

       

        public int IDTAIKHOAN { get; set; }
        [StringLength(50)]
        public string TIEUDE_TINTUC { get; set; }
        [Required]
        [StringLength(250)]
        public string MOTA_TINTUC { get; set; }

        [StringLength(50)]
        [AllowHtml]
        public string NOIDUNG { get; set; }
        [Required]
        [StringLength(250)]
        public string HINHANH_TINTUC { get; set; }

        [StringLength(250)]
        public string GHICHU_TINTUC { get; set; }


        public bool IS_DELETE { get; set; }
        [StringLength(50)]
        public string CREATEBY { get; set; }

        public Nullable<DateTime> CREATEDATE { get; set; }

        public Nullable<DateTime> MODIFILEDDATE { get; set; }
        [StringLength(50)]
        public string MODIFILEDBY { get; set; }



    }
}