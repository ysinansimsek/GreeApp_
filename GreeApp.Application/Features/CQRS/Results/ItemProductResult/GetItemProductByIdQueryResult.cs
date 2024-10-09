using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Results.ItemProductResult
{
    public class GetItemProductByIdQueryResult
    {
        public int ItemProductId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public List<Item> Items { get; set; }
        public List<Product> Products { get; set; }
    }
}
