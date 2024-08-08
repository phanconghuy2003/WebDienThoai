using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class LoaitaiKhoanModel
    {


        [Required]
        public string IDLOAITAIKHOAN { get; set; }

        [StringLength(50)]
        public string TENLOAITAIKHOAN { get; set; }

        [StringLength(250)]
        public string GHICHU { get; set; }
        public Nullable<bool> IS_DELETE { get; set; }
        [StringLength(50)]
        public string CREATEBY { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd-MM-yyyy HH:mm}")]
        public Nullable<DateTime> CREATEDATE { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public Nullable<DateTime> MODIFILEDDATE { get; set; }
        [StringLength(50)]
        public string MODIFILEDBY { get; set; }


    }
}