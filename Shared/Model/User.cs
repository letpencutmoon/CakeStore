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
        public string Name { get; set; } = string.Empty;

        public string Tel { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime DataCreated { get; set; } = DateTime.Now;
    }
}
