using bandienthoai.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    [Serializable]
    public class CartItem
    {
        
        public SANPHAM Product { get; set; }
        public int Quantity { get; set; }
        //public int Promotion { get; set; }
    }

}