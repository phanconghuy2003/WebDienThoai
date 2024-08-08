namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTIETPHIEUYCNHAPKHO")]
    public partial class CTIETPHIEUYCNHAPKHO
    {
        [Key]
        public decimal CTIETPHIEUYCNHAPKHO_ID { get; set; }

        public long PHIEUYCNHAPKHO_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        public int SOLUONG_CTYCNHAPKHO { get; set; }

        public decimal DONGIA_CTYCNHAPKHO { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual PHIEUYEUCAUNHAPKHO PHIEUYEUCAUNHAPKHO { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
