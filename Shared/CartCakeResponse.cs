using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared
{
    public class CartCakeResponse
    {
        public int CakeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CakeTypeId { get; set; }
        public string CakeType { get; set; } = string.Empty;
        public string Imgurl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
