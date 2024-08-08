namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMAGEPRODDUCT")]
    public partial class IMAGEPRODDUCT
    {
        public int ID { get; set; }

        public decimal IDPRODUCT { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        [StringLength(50)]
        public string ALT { get; set; }

        [StringLength(250)]
        public string IMAGE { get; set; }
    }
}
