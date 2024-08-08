namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUNHAPKHO")]
    public partial class CHITIETPHIEUNHAPKHO
    {
        [Key]
        public decimal CTIETPHIEUNHAPKHO_ID { get; set; }

        public decimal PHIEUNHAPKHO_ID { get; set; }

        public decimal SANPHAM_ID { get; set; }

        public int SOLUONG_CTIETNHAPKHO { get; set; }

        public decimal DONGIA_CTIETNHAPKHO { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}
