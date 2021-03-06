using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dothenghia_shop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]

        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string repasss { set; get; }

        

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        public string Email { set; get; }

       
    }
}