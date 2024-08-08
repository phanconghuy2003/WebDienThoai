namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIA")]
    public partial class DANHGIA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDTAIKHOAN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SANPHAM_ID { get; set; }

        [StringLength(250)]
        public string NOIDUNG_DANHGIA { get; set; }

        public int? SOSAO { get; set; }

        [StringLength(30)]
        public string THOIGIAN_DANHGIA { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
