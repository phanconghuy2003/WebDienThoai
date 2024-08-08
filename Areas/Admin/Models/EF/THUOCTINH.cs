namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOCTINH")]
    public partial class THUOCTINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOCTINH()
        {
            CHITIETTHUOCTINHs = new HashSet<CHITIETTHUOCTINH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long THUOCTINH_ID { get; set; }

        public long? IDLOAITT { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_THUOCTINH { get; set; }

        [StringLength(250)]
        public string GIATRI_THUOCTINH { get; set; }

        [StringLength(250)]
        public string GHICHU_THUOCTINH { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUOCTINH> CHITIETTHUOCTINHs { get; set; }

        public virtual LOAITT LOAITT { get; set; }
    }
}
