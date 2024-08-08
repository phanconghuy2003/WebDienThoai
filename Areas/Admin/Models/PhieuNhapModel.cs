using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class PhieuNhapModel
    {
        [StringLength(50)]
        public string NameProduct { set; get; }
        [StringLength(50)]
        public string NameNCC { set; get; }
        public long? Quality { set; get; }
        public decimal? Price { set; get; }

        
                                  
                                  
    }
}