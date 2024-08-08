namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [Key]
        public long TINTUC_ID { get; set; }

        public int IDTAIKHOAN { get; set; }

        [StringLength(250)]
        public string TIEUDE_TINTUC { get; set; }

        [StringLength(250)]
        public string MOTA_TINTUC { get; set; }

        [StringLength(900)]
        public string NOIDUNG { get; set; }

        [StringLength(250)]
        public string HINHANH_TINTUC { get; set; }

        [StringLength(250)]
        public string GHICHU_TINTUC { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}
