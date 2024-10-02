﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
        public List<ProductPricing> ProductPricings { get; set; }
    }
}
