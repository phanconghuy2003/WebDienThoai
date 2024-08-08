namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CREDENTIAL")]
    public partial class CREDENTIAL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string USERGROUPID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ROLEID { get; set; }
    }
}
