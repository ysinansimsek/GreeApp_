using GreeApp.Application.FooterAddresss.Mediator.Queries.FooterAddressQureies;
using GreeApp.Application.FooterAddresss.Mediator.Results.FooterAddressResults;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQureyResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        async Task<List<GetFooterAddressQureyResult>> IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQureyResult>>.Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQureyResult
            {
                Address = x.Address,
                Description = x.Description,
            }).ToList();
        }
    }
}
