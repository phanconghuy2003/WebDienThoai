namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHASANXUAT")]
    public partial class NHASANXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHASANXUAT()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        [Key]
        public int ID_NSX { get; set; }

        [StringLength(10)]
        public string MANSX { get; set; }

        [Required]
        [StringLength(50)]
        public string TEN_NSX { get; set; }

        [StringLength(11)]
        public string SDT_NSX { get; set; }

        [StringLength(250)]
        public string MOTA_NSX { get; set; }

        [StringLength(300)]
        public string DIACHI_NSX { get; set; }

        [StringLength(250)]
        public string GHICHU_NSX { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
