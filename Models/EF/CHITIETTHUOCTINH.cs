namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUOCTINH")]
    public partial class CHITIETTHUOCTINH
    {
        [Key]
        public decimal CHITIETTHUOCTINH_ID { get; set; }

        public long? IDSANPHAM { get; set; }

        public long THUOCTINH_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_CHITIETTHUOCTINH { get; set; }

        [StringLength(250)]
        public string GIATRI_CHITIETTHUOCTINH { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual THUOCTINH THUOCTINH { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
