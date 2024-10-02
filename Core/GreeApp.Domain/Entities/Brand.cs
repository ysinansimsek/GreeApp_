﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        List<Product> Products { get; set; }    
    }
}
