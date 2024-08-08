namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTIETPHIEUDOITRA")]
    public partial class CTIETPHIEUDOITRA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CTIETPHIEUDOITRA_ID { get; set; }

        public long PHIEUDOITRA_ID { get; set; }

        public long SANPHAM_ID { get; set; }

        [StringLength(250)]
        public string LYDO_CTDOITRA { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual PHIEUDOITRA PHIEUDOITRA { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
