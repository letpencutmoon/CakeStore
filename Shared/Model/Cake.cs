using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class Cake
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty ;

        public string Imgurl { get; set; } = string.Empty ;

        //[Column(TypeName ="decimal(18,2)")]
        //public decimal Price { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public List<CakeVariant> CakeVariants { get; set; } = new();
        public bool Visible { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
