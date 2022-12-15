using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class CakeVariant
    {
        [JsonIgnore]
        public Cake Cake { get; set; }

        public int CakeId { get; set; }
        public CakeType CakeType { get; set; }
        public int CakeTypeId { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
    }
}
