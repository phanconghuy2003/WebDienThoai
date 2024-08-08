namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        public long ID { get; set; }

        public DateTime? CREATEDATE { get; set; }

        public long? CUSTOMERID { get; set; }

        [StringLength(50)]
        public string SHIPNAME { get; set; }

        [StringLength(50)]
        public string SHIPMOBILE { get; set; }

        [StringLength(250)]
        public string SHIPDDRESS { get; set; }

        [StringLength(50)]
        public string SHIPEMAIL { get; set; }

        public int? STATUS { get; set; }

        public bool? IS_DELETE { get; set; }
    }
}
