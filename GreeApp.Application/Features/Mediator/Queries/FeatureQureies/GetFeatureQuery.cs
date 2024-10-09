using GreeApp.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.Mediator.Queries.FeatureQureies
{
    public class GetFeatureQuery : IRequest<List<GetFeatureQureyResult>>
    {

    }
}
