using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared
{
    public class OrderDetailsCakeResponse
    {
        public int CakeId { get; set; }
        public string Name { get; set; }
        public string CakeType { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
