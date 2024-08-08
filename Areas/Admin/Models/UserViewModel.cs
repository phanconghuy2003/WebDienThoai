using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Areas.Admin.Models
{
    public class UserViewModel
    {
       [Key]
            public int ID { set; get; }
        public string IDTypeUser { set; get; }
        [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]     
            public string UserName { get; set; }

        [Display(Name = "Mật khẩu cũ")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài tối thiểu là 6 ký tự")]
    
        public string PasswordOld { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài tối thiểu là 6 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu không đúng!")]
            public string ConfirmPassword { get; set; }
            [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
            [Display(Name = "Họ tên")]
            public string Name { get; set; }
            [Display(Name = "Địa chỉ")]
            public string Address { get; set; }
            [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
            [Display(Name = "Số điện thoại")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "Yêu cầu nhập email")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Display(Name = "Tỉnh/thành")]
            public string Province { get; set; }
            [Display(Name = "Quận/huyện")]
            public string District { get; set; }
        public  int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }


    }
    }