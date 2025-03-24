﻿using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserSigninViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
