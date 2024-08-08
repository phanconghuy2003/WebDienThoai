namespace bandienthoai.Areas.Admin.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TEXT { get; set; }

        public int? PARENTID { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        [StringLength(50)]
        public string TARGET { get; set; }

        public int? DISPLAYORDER { get; set; }

        public int? TYPEID { get; set; }

        public bool? STATUS { get; set; }

        public bool? IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        public virtual MENUTYPE MENUTYPE { get; set; }
    }
}
