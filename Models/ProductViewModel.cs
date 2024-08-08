
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Models
{
    public class ProductViewModel
    {
        [Key]
        public decimal ID { get; set; }
        public DateTime? NgayKTKM { get; set; }
        public decimal Price { get; set; }
        public int Promotion { get; set; }
        public int? Luotxem { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string CateName { get; set; }

        [StringLength(50)]
        public string CateMetatitle { get; set; }
        
        [StringLength(50)]
        public string MetaTitle { get; set; }
        [StringLength(50)]

        public string Images { get; set; }
       
        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFILEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }
    }
}