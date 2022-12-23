using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class CakeType
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
