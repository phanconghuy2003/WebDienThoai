namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERDETAIL")]
    public partial class ORDERDETAIL
    {
        public long ID { get; set; }

        public long? ORDERID { get; set; }

        public long? QUANTITY { get; set; }

        public decimal? PRICE { get; set; }

        public long? PRODUCTID { get; set; }

        public int? GIAMGIA { get; set; }
    }
}
