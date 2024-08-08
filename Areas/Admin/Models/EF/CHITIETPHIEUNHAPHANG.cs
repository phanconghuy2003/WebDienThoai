namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUNHAPHANG")]
    public partial class CHITIETPHIEUNHAPHANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CHITIETPHIEUNHAPHANG_ID { get; set; }

        public long PHIEUNHAPHANG_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        public int SOLUONGNHAP { get; set; }

        public int SOLUONGTHUCNHAP { get; set; }

        public double? DONGIA_CTNHAPHANG { get; set; }

        public bool? TINHTRANG_CTPHIEUNHAPHANG { get; set; }

        [StringLength(250)]
        public string LYDO_CTPHIEUNHAPHANG { get; set; }

        [StringLength(250)]
        public string GHICHU_CTIETPHIEUNHAPHANG { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual PHIEUNHAPHANG PHIEUNHAPHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
