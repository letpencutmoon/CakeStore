using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class User
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string Tel { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; } = string.Empty;
    }
}
