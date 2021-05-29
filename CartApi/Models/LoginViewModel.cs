using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CartApi.Models
{
    public class LoginViewModel
    {
        [Required]
        public string LoginUserName { get; set; }
        [Required]
        public string LoginPassword { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        public string RegisterUserName { get; set; }
        [Required]
        public string RegisterPassword { get; set; }
    }
}