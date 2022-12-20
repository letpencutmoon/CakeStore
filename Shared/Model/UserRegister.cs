using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class UserRegister
    {
        [Required, Phone]
        public string Tel { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password",ErrorMessage = "前后密码不一致")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
