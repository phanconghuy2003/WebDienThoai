using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập tên đăng nhập")]
        public string userName{ set; get; }
        [Required(ErrorMessage = "Mời bạn nhập Mật khẩu")]
        public string passWord { set; get; }
        public bool remember { set; get; }
    }
}