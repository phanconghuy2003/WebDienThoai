namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FOOTER")]
    public partial class FOOTER
    {
        [Key]
        public long IDFOOTER { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}
