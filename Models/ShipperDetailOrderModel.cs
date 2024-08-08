using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class ShipperDetailOrderModel
    {
       
       
        public long IDProduct { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }

        public decimal? Price { get; set; }

        public int? Soluong { get; set; }


      

    }
}