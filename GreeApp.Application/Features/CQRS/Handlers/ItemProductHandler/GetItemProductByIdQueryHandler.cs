using GreeApp.Application.Features.CQRS.Queries.ItemProductQueries;
using GreeApp.Application.Features.CQRS.Results.ItemProductResult;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.ItemProductHandler
{
    public class GetItemProductByIdQueryHandler
    {
        private readonly IRepository<ItemProduct> _repository;
        public GetItemProductByIdQueryHandler(IRepository<ItemProduct> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<GetItemProductByIdQueryResult> Handle(GetItemProductByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetItemProductByIdQueryResult
            {
                ItemProductId = values.ItemProductId,
                //Description = values.Description,
                //Barcode = values.Barcode,
                //Name = values.Name,
            };
        }
    }
}
