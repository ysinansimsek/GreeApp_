using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class ProductFeature
    {
        public int ProductFeatureId { get; set; }

        public int ProductId { get; set; }
        public int FeatureId { get; set; }

        public Product Product { get; set; }
        public Feature Feature { get; set; }
        public bool Active { get; set; }

    }
}
