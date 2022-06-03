﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dothenghia_shop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}