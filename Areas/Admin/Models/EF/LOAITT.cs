namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITT")]
    public partial class LOAITT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITT()
        {
            THUOCTINHs = new HashSet<THUOCTINH>();
        }

        [Key]
        public long IDLOAITHUOCTINH { get; set; }

        [StringLength(50)]
        public string TENLOAI { get; set; }

        public bool? IS_DELETE { get; set; }

        public DateTime? CREATEBY { get; set; }

        [StringLength(50)]
        public string MODIFILEBY { get; set; }

        public DateTime? MODIFILEDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUOCTINH> THUOCTINHs { get; set; }
    }
}
