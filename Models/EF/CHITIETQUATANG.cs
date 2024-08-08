namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETQUATANG")]
    public partial class CHITIETQUATANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CHITIETQUATANG_ID { get; set; }

        public long QUATANG_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        public int SOLUONGQUATANG { get; set; }

        [StringLength(250)]
        public string GHICHU_QUATANG { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual QUATANG QUATANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
