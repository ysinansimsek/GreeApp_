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
    public class GetItemProductQueryHandler
    {
        private readonly IRepository<ItemProduct> _repository;
        public GetItemProductQueryHandler(IRepository<ItemProduct> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetItemProductQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetItemProductQueryResult
            {
                ItemProductId = x.ItemProductId,
                //Description = x.Description,
                //Barcode = x.Barcode,
                //Name = x.Name,
            }).ToList();
    }
    }
 
}
