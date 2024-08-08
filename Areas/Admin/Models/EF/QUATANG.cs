namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUATANG")]
    public partial class QUATANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUATANG()
        {
            CHITIETQUATANGs = new HashSet<CHITIETQUATANG>();
        }

        [Key]
        public long QUATANG_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TENQUATANG { get; set; }

        public DateTime NGAYBATDAU_QUATANG { get; set; }

        public DateTime NGAYKETTHUC_QUATANG { get; set; }

        public int? TONGSOLUONG_QUATANG { get; set; }

        [StringLength(250)]
        public string GHICHU_QUATANG { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETQUATANG> CHITIETQUATANGs { get; set; }
    }
}
