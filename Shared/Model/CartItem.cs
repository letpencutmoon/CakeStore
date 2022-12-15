using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared.Model
{
    public class CartItem
    {
        public int CakeId { get; set; }
        public int CakeTypeId { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
