namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUBAOHANH")]
    public partial class PHIEUBAOHANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUBAOHANH()
        {
            CTIETPHIEUBAOHANHs = new HashSet<CTIETPHIEUBAOHANH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal PHIEUBAOHANH_ID { get; set; }

        public long HOADON_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SOPHIEUBAOHANH { get; set; }

        public DateTime? NGAYLAP { get; set; }

        public int? THOIHAN { get; set; }

        [StringLength(50)]
        public string NGUOINHAN { get; set; }

        [StringLength(900)]
        public string GHICHU_PHIEUBAOHANH { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUBAOHANH> CTIETPHIEUBAOHANHs { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
