using GreeApp.Application.Features.CQRS.Results.BrandResult;
using GreeApp.Application.Features.Mediator.Queries.FeatureQureies;
using GreeApp.Application.Features.Mediator.Results.FeatureResults;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQureyResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        async Task<List<GetFeatureQureyResult>> IRequestHandler<GetFeatureQuery, List<GetFeatureQureyResult>>.Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQureyResult
            {
                Name = x.Name,
            }).ToList();
        }
    }
}
