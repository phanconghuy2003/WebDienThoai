using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [StringLength(50)]
        public string RoleID { set; get; }
        [StringLength(50)]
        public string  GroupID{ set; get; }
        [StringLength(50)]
        public string NameGroup { set; get; }
        [StringLength(50)]
        public string NameRole { set; get; }
    }
}