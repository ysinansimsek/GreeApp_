﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class ProductPricing
    {
        public int ProductPricingId { get; set; }
        public int PricingId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Pricing Pricing { get; set; }

        public decimal Amount { get; set; }

    }
}
