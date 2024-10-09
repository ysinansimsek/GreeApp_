using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Commands.ItemProductCommand
{
    public class CreateItemProductCommand
    {
        public int ItemProductId { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public string ImageUrl { get; set; }
        //public List<ItemProductFeature> ItemProductFeatures { get; set; }
        //public List<ItemProductDescription> ItemProductDescriptions { get; set; }
        //public List<ItemProductPricing> ItemProductPricings { get; set; }
        public List<ItemProduct> ItemProductItems { get; set; }
    }
}
