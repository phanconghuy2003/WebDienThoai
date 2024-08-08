namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTIETPHIEUBAOHANH")]
    public partial class CTIETPHIEUBAOHANH
    {
        [Key]
        public long CTIETPHIEUBAOHANH_ID { get; set; }

        public decimal PHIEUBAOHANH_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        [StringLength(30)]
        public string NGAYHEN { get; set; }

        [StringLength(30)]
        public string NGAYTRA { get; set; }

        [StringLength(50)]
        public string KYTHUATKIEMTRA { get; set; }

        [StringLength(50)]
        public string KYTHUATSUAMAY { get; set; }

        public bool? TINHTRANG_CTBAOHANH { get; set; }

        [StringLength(500)]
        public string GHICHU_CTIETBAOHANH { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual PHIEUBAOHANH PHIEUBAOHANH { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
