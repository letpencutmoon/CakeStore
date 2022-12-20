using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class UserLogin
    {
        [Required]
        public string Tel { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
