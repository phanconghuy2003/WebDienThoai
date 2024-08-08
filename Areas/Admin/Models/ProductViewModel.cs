using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public long Id { set; get; }
      
        public long IdNCC { set; get; }
        public string NameNCC { set; get; }
        public decimal IdTypeProduct { set; get; }
        public string NameTypeProduct { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public long? SoLuong { set; get; }
        public decimal? Price { set; get; }
     
    }
}