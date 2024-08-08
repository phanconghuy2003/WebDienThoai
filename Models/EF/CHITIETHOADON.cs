namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CHITIETHOADON_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        public long HOADON_ID { get; set; }

        public double GIABAN { get; set; }

        public int SOLUONGBAN { get; set; }

        public bool? TINHTRANG_CTIETHOADON { get; set; }

        [StringLength(500)]
        public string LYDO_CTIETHOADON { get; set; }

        [StringLength(250)]
        public string GHICHU_CTIETHOADON { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
