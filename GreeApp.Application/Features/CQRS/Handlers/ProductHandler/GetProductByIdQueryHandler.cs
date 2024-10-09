using GreeApp.Application.Features.CQRS.Queries.ProductQueries;
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
    public class GetProductByIdQueryHandler
    {
        private readonly IRepository<Product> _repository;
        public GetProductByIdQueryHandler(IRepository<Product> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetProductByIdQueryResult
            {
                ProductId = values.ProductId,
                Description = values.Description,
                Barcode = values.Barcode,
                Name = values.Name,
            };
        }
    }
}
