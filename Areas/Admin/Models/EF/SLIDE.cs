namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDE")]
    public partial class SLIDE
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string IMAGE { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        public int? DISPLAYORDER { get; set; }

        [StringLength(250)]
        public string GHICHU { get; set; }

        public int? STATUS { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}
