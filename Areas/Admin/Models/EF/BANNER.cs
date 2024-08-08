namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANNER")]
    public partial class BANNER
    {
        [Key]
        public long BANNER_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string HINH { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

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
