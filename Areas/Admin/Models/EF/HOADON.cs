namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            PHIEUBAOHANHs = new HashSet<PHIEUBAOHANH>();
            PHIEUDOITRAs = new HashSet<PHIEUDOITRA>();
        }

        [Key]
        public long HOADON_ID { get; set; }

        public int IDKHACHHANG { get; set; }

        public int SHIPPER_ID { get; set; }

        public int IDTOAIKHOAN { get; set; }

        public bool HINHTHUCTHANHTOAN { get; set; }

        public DateTime? NGAYXUATHD { get; set; }

        public DateTime? NGAYBDGIAO { get; set; }

        public DateTime? NGAYKTGIAO { get; set; }

        public double? THANHTIEN_HOADON { get; set; }

        [Required]
        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [StringLength(250)]
        public string GHICHU_HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public virtual SHIPPER SHIPPER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUBAOHANH> PHIEUBAOHANHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDOITRA> PHIEUDOITRAs { get; set; }
    }
}
