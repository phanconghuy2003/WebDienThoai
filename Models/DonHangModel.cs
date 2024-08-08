using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class DonHangModel
    {

        [Key]
        public long ID { get; set; }

         [StringLength(50)]
        public string SHIPNAME { get; set; }

       
        [StringLength(50)]
        public string SHIPMOBILE { get; set; }


        [StringLength(250)]
        public string SHIPDDRESS { get; set; }

       
        [StringLength(50)]
        public string SHIPEMAIL { get; set; }
    }
}