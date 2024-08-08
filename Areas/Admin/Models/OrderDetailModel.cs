using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class OrderDetailModel
    {
        [Key]
        public long ID { get; set; }
        
        public int Promotion { get; set; }
        public long OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public long ProductId { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }
    


    }
}