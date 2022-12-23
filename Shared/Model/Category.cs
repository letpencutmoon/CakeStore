using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
