using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    [Serializable]
    public class BannerModel
    {
        [Key]
        public long BANNER_ID { get; set; }

        public int TENTK { get; set; }

        [Required]
        [StringLength(250)]
        public string HINH { get; set; }

        [Required]
        [StringLength(250)]
        public string LINK { get; set; }
        [DefaultValue(1)]
        public int VITRI { get; set; }

        [StringLength(250)]
        public string TIEUDE { get; set; }

        [StringLength(250)]
        public string GHICHU_BANNER { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}