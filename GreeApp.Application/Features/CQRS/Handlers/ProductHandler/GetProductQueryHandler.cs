using GreeApp.Application.Features.CQRS.Results.ProductResult;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.ProductHandler
{
    public class GetProductQueryHandler
    {
        private readonly IRepository<Product> _repository;
        public GetProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                Description = x.Description,
                Barcode = x.Barcode,
                Name = x.Name,
            }).ToList();
    }
    }
 
}
