namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        public long ID { get; set; }

        [Column(TypeName = "text")]
        public string CONTENT { get; set; }

        public bool? STATUS { get; set; }
    }
}
