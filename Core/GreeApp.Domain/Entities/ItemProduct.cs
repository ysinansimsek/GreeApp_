using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class ItemProduct
    {
        public int ItemProductId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public List<Item> Items { get; set; }
        public List<Product> Products { get; set; }


    }
}
