namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANGGIA")]
    public partial class BANGGIA
    {
        [Key]
        public long IDGIA { get; set; }

        public long? IDSANPHAM { get; set; }

        public double? GIANHAP { get; set; }

        public double? GIABAN { get; set; }

        public DateTime? THOIGIANBD { get; set; }

        public DateTime? THOIGIANKT { get; set; }

        public bool? IS_DELETE { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
