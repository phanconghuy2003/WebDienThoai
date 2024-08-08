using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public long SANPHAM_ID { get; set; }

        public decimal LOAISANPHAM_ID { get; set; }

        public int ID_NSX { get; set; }

        public int ID_NCC { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string NOIDUNG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_SANPHAM { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_SANPHAM { get; set; }
        [StringLength(250)]
        public string Image1 { get; set; }
        [StringLength(250)]
        public string Image2 { get; set; }
         [StringLength(250)]
        public string Image3 { get; set; }
        [StringLength(250)]
        public string Image4 { get; set; }
        [StringLength(250)]
        public string Image5 { get; set; }
        [StringLength(250)]
        public string Image6 { get; set; }
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
    }
}