using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class LoaiTinTucModel
    {
        [Key]
        public int IDLOAITINTUC { get; set; }

        [Required]
        [StringLength(50)]
        public string TENLOAITIN { get; set; }
        public Nullable<bool> IS_DELETE { get; set; }
        [StringLength(50)]
        public string CREATEBY { get; set; }

        public Nullable<DateTime> CREATEDATE { get; set; }

        public Nullable<DateTime> MODIFILEDDATE { get; set; }
        [StringLength(50)]
        public string MODIFILEDBY { get; set; }
    }
}