using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Commands.BrandCommand
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public List<Product> Products { get; set; }
    }
}
