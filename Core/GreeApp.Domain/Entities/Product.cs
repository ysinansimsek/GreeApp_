using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }    
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public string Barcode     { get; set; }
        public string ImageUrl { get; set; }    
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductDescription> ProductDescriptions { get; set; }
        public List<ProductPricing> ProductPricings { get; set; }
        public List<ItemProduct> ProductItems { get; set; }


    }
}
