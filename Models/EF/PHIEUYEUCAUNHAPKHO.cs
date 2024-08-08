namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUYEUCAUNHAPKHO")]
    public partial class PHIEUYEUCAUNHAPKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUYEUCAUNHAPKHO()
        {
            CTIETPHIEUYCNHAPKHOes = new HashSet<CTIETPHIEUYCNHAPKHO>();
        }

        [Key]
        public long PHIEUYCNHAPKHO_ID { get; set; }

        public long PHIEUNHAPHANG_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SOPHIEUYCNHAPKHO { get; set; }

        public bool? TINHTRANG_PHIEUYCNHAPKHO { get; set; }

        [StringLength(250)]
        public string GHICHU_PHIEUYCNHAPKHO { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUYCNHAPKHO> CTIETPHIEUYCNHAPKHOes { get; set; }

        public virtual PHIEUNHAPHANG PHIEUNHAPHANG { get; set; }
    }
}
