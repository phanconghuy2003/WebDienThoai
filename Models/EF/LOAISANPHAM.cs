namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAISANPHAM")]
    public partial class LOAISANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAISANPHAM()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal LOAISANPHAM_ID { get; set; }

        [StringLength(2)]
        public string LANGUAGE { get; set; }

        public int? DISPLAYORDER { get; set; }

        public long? PARENTID { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_LOAISANPHAM { get; set; }

        [StringLength(250)]
        public string GHICHU_LOAISANPHAM { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
