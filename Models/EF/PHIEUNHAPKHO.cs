namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPKHO")]
    public partial class PHIEUNHAPKHO
    {
        [Key]
        public long PHIEUNHAPKHO_ID { get; set; }

        public long IDNHAPHANG { get; set; }

        public long IDSANPHAM { get; set; }

        public long? SOLUONG { get; set; }

        public long IDNCC { get; set; }

        public decimal? DONGIA { get; set; }

        [StringLength(250)]
        public string GHICHU_PHIEUNHAPKHO { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}
