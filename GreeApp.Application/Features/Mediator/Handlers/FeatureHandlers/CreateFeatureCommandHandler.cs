﻿using GreeApp.Application.Features.Mediator.Commands.FeatureCommands;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Feature
            {
                Name = request.Name,
            });
        }
    }
}
