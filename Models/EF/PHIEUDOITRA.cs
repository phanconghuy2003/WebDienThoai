namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDOITRA")]
    public partial class PHIEUDOITRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDOITRA()
        {
            CTIETPHIEUDOITRAs = new HashSet<CTIETPHIEUDOITRA>();
        }

        [Key]
        public long PHIEUDOITRA_ID { get; set; }

        public long HOADON_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SOPHIEUDOITRA { get; set; }

        public DateTime? NGAYDOITRA { get; set; }

        [StringLength(50)]
        public string NGUOINHAN_DOITRA { get; set; }

        [StringLength(250)]
        public string LYDO { get; set; }

        [StringLength(250)]
        public string GHICHU_PHIEUDOITRA { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUDOITRA> CTIETPHIEUDOITRAs { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
