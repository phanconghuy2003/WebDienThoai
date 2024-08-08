namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        [Key]
        public long BINHLUAN_ID { get; set; }

        public int TENTK { get; set; }

        public long SANPHAM_ID { get; set; }

        [StringLength(30)]
        public string THOIGIAN_BINHLUAN { get; set; }

        [StringLength(900)]
        public string NOIDUNG { get; set; }

        public decimal? BINHLUANCHA_ID { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
