using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class NhaCungCapModel
    {
        [Key]
        public int ID_NCC { get; set; }

        [StringLength(10)]
        public string MANCC { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_NCC { get; set; }

        [StringLength(300)]
        public string DIACHI_NCC { get; set; }

        [StringLength(250)]
        public string EMAIL_NCC { get; set; }

        [StringLength(11)]
        public string SDT_NCC { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}