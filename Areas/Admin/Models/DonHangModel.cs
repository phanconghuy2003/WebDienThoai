using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class DonHangModel
    {
        [Key]
        public long ID { get; set; }

        public int IDTOAIKHOAN { get; set; }
 
        public bool HINHTHUCTHANHTOAN { get; set; }
        [StringLength(50)]
        public string HOTEN { get; set; }
        [StringLength(50)]
        public string SDT { get; set; }
        [StringLength(50)]
        public string GMAIL { get; set; }
        [StringLength(50)]
        public string DIACHI { get; set; }
        public DateTime? NGAYXUATHD { get; set; }

        public int? SOLUONG { get; set; }
        public decimal? DONGIA { get; set; }
       
        [StringLength(50)]
        public string TENSANPHAM { get; set; }
        [StringLength(255)]
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
    }
}