namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            BANGGIAs = new HashSet<BANGGIA>();
            BINHLUANs = new HashSet<BINHLUAN>();
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            CHITIETPHIEUNHAPHANGs = new HashSet<CHITIETPHIEUNHAPHANG>();
            CHITIETQUATANGs = new HashSet<CHITIETQUATANG>();
            CHITIETTHUOCTINHs = new HashSet<CHITIETTHUOCTINH>();
            CTIETPHIEUBAOHANHs = new HashSet<CTIETPHIEUBAOHANH>();
            CTIETPHIEUDOITRAs = new HashSet<CTIETPHIEUDOITRA>();
            CTIETPHIEUYCNHAPKHOes = new HashSet<CTIETPHIEUYCNHAPKHO>();
            DANHGIAs = new HashSet<DANHGIA>();
        }

        [Key]
        public long SANPHAM_ID { get; set; }

        public decimal LOAISANPHAM_ID { get; set; }

        public int ID_NSX { get; set; }

        public int ID_NCC { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SANPHAM { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_SANPHAM { get; set; }

        [StringLength(250)]
        public string GHICHU_SANPHAM { get; set; }

        public DateTime? NGAYKTKM { get; set; }

        [StringLength(250)]
        public string MOTA_SANPHAM { get; set; }

        public decimal? GIANHAP { get; set; }

        public decimal GIA_SANPHAM { get; set; }

        public bool TRANGTHAI { get; set; }

        [StringLength(250)]
        public string HINHANH_SANPHAM { get; set; }

        public long? SOLUONGTON { get; set; }

        public int? TONTOITHIEU { get; set; }

        public int? LUOTXEM { get; set; }

        [StringLength(500)]
        public string SPDIKEM { get; set; }

        public int KHUYENMAI { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGGIA> BANGGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAPHANG> CHITIETPHIEUNHAPHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETQUATANG> CHITIETQUATANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUOCTINH> CHITIETTHUOCTINHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUBAOHANH> CTIETPHIEUBAOHANHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUDOITRA> CTIETPHIEUDOITRAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTIETPHIEUYCNHAPKHO> CTIETPHIEUYCNHAPKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
