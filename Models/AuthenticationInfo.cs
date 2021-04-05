using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{
    public class AuthenticationInfo
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
