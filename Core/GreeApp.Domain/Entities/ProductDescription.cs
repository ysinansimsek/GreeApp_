using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class ProductDescription
    {
        public int ProductDescriptionId { get; set; }
        public string Details { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

    }
}
