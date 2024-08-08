namespace bandienthoai.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QlBanHangDbContext : DbContext
    {
        public QlBanHangDbContext()
            : base("name=QlBanHangDbContext")
        {
        }

        public virtual DbSet<BANGGIA> BANGGIAs { get; set; }
        public virtual DbSet<BANNER> BANNERs { get; set; }
        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAPHANG> CHITIETPHIEUNHAPHANGs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAPKHO> CHITIETPHIEUNHAPKHOes { get; set; }
        public virtual DbSet<CHITIETQUATANG> CHITIETQUATANGs { get; set; }
        public virtual DbSet<CHITIETTHUOCTINH> CHITIETTHUOCTINHs { get; set; }
        public virtual DbSet<CONTACT> CONTACTs { get; set; }
        public virtual DbSet<CREDENTIAL> CREDENTIALs { get; set; }
        public virtual DbSet<CTIETPHIEUBAOHANH> CTIETPHIEUBAOHANHs { get; set; }
        public virtual DbSet<CTIETPHIEUDOITRA> CTIETPHIEUDOITRAs { get; set; }
        public virtual DbSet<CTIETPHIEUYCNHAPKHO> CTIETPHIEUYCNHAPKHOes { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<FOOTER> FOOTERs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<IMAGEPRODDUCT> IMAGEPRODDUCTs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<LOAITAIKHOAN> LOAITAIKHOANs { get; set; }
        public virtual DbSet<LOAITINTUC> LOAITINTUCs { get; set; }
        public virtual DbSet<LOAITT> LOAITTs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MENUTYPE> MENUTYPEs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAILs { get; set; }
        public virtual DbSet<PHIEUBAOHANH> PHIEUBAOHANHs { get; set; }
        public virtual DbSet<PHIEUDOITRA> PHIEUDOITRAs { get; set; }
        public virtual DbSet<PHIEUNHAPHANG> PHIEUNHAPHANGs { get; set; }
        public virtual DbSet<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUYEUCAUNHAPKHO> PHIEUYEUCAUNHAPKHOes { get; set; }
        public virtual DbSet<QUATANG> QUATANGs { get; set; }
        public virtual DbSet<RECOMMENDER> RECOMMENDERs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<SHIPPER> SHIPPERs { get; set; }
        public virtual DbSet<SLIDE> SLIDEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THUOCTINH> THUOCTINHs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANNER>()
                .Property(e => e.LINK)
                .IsUnicode(false);

            modelBuilder.Entity<BINHLUAN>()
                .Property(e => e.BINHLUANCHA_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETPHIEUNHAPKHO>()
                .Property(e => e.CTIETPHIEUNHAPKHO_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETPHIEUNHAPKHO>()
                .Property(e => e.PHIEUNHAPKHO_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETPHIEUNHAPKHO>()
                .Property(e => e.SANPHAM_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETPHIEUNHAPKHO>()
                .Property(e => e.DONGIA_CTIETNHAPKHO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHITIETTHUOCTINH>()
                .Property(e => e.CHITIETTHUOCTINH_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.CONTENT)
                .IsUnicode(false);

            modelBuilder.Entity<CREDENTIAL>()
                .Property(e => e.USERGROUPID)
                .IsUnicode(false);

            modelBuilder.Entity<CREDENTIAL>()
                .Property(e => e.ROLEID)
                .IsUnicode(false);

            modelBuilder.Entity<CTIETPHIEUBAOHANH>()
                .Property(e => e.PHIEUBAOHANH_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTIETPHIEUBAOHANH>()
                .Property(e => e.NGAYHEN)
                .IsUnicode(false);

            modelBuilder.Entity<CTIETPHIEUBAOHANH>()
                .Property(e => e.NGAYTRA)
                .IsUnicode(false);

            modelBuilder.Entity<CTIETPHIEUYCNHAPKHO>()
                .Property(e => e.CTIETPHIEUYCNHAPKHO_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTIETPHIEUYCNHAPKHO>()
                .Property(e => e.DONGIA_CTYCNHAPKHO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.PHIEUBAOHANHs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.PHIEUDOITRAs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IMAGEPRODDUCT>()
                .Property(e => e.IDPRODUCT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAISANPHAM>()
                .Property(e => e.LOAISANPHAM_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LOAISANPHAM>()
                .Property(e => e.LANGUAGE)
                .IsUnicode(false);

            modelBuilder.Entity<LOAISANPHAM>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.LOAISANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITAIKHOAN>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITT>()
                .HasMany(e => e.THUOCTINHs)
                .WithOptional(e => e.LOAITT)
                .HasForeignKey(e => e.IDLOAITT);

            modelBuilder.Entity<MENUTYPE>()
                .HasMany(e => e.Menus)
                .WithOptional(e => e.MENUTYPE)
                .HasForeignKey(e => e.TYPEID);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANCC)
                .IsFixedLength();

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT_NCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.MANSX)
                .IsFixedLength();

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.SDT_NSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHASANXUAT>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NHASANXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPMOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERDETAIL>()
                .Property(e => e.PRICE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUBAOHANH>()
                .Property(e => e.PHIEUBAOHANH_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUBAOHANH>()
                .Property(e => e.SOPHIEUBAOHANH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUBAOHANH>()
                .HasMany(e => e.CTIETPHIEUBAOHANHs)
                .WithRequired(e => e.PHIEUBAOHANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUDOITRA>()
                .Property(e => e.SOPHIEUDOITRA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDOITRA>()
                .Property(e => e.LYDO)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDOITRA>()
                .HasMany(e => e.CTIETPHIEUDOITRAs)
                .WithRequired(e => e.PHIEUDOITRA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPHANG>()
                .HasMany(e => e.CHITIETPHIEUNHAPHANGs)
                .WithRequired(e => e.PHIEUNHAPHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPHANG>()
                .HasMany(e => e.PHIEUYEUCAUNHAPKHOes)
                .WithRequired(e => e.PHIEUNHAPHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPKHO>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUYEUCAUNHAPKHO>()
                .HasMany(e => e.CTIETPHIEUYCNHAPKHOes)
                .WithRequired(e => e.PHIEUYEUCAUNHAPKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUATANG>()
                .HasMany(e => e.CHITIETQUATANGs)
                .WithRequired(e => e.QUATANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.LOAISANPHAM_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GIANHAP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GIA_SANPHAM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.BANGGIAs)
                .WithOptional(e => e.SANPHAM)
                .HasForeignKey(e => e.IDSANPHAM);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.BINHLUANs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETPHIEUNHAPHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETQUATANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETTHUOCTINHs)
                .WithOptional(e => e.SANPHAM)
                .HasForeignKey(e => e.IDSANPHAM);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTIETPHIEUBAOHANHs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTIETPHIEUDOITRAs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTIETPHIEUYCNHAPKHOes)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DANHGIAs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.SANPHAM)
                .HasForeignKey(e => e.IDItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHIPPER>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.SHIPPER)
                .HasForeignKey(e => e.SHIPPER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.USERGROUPID)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.BINHLUANs)
                .WithRequired(e => e.TAIKHOAN)
                .HasForeignKey(e => e.TENTK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.DANHGIAs)
                .WithRequired(e => e.TAIKHOAN)
                .HasForeignKey(e => e.IDTAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.TAIKHOAN)
                .HasForeignKey(e => e.IDTOAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.TAIKHOAN)
                .HasForeignKey(e => e.IDUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOCTINH>()
                .HasMany(e => e.CHITIETTHUOCTINHs)
                .WithRequired(e => e.THUOCTINH)
                .WillCascadeOnDelete(false);
        }
    }
}
