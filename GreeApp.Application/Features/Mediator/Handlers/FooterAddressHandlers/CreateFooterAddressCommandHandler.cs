﻿using GreeApp.Application.FooterAddresss.Mediator.Commands.FooterAddressCommands;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,

            });
        }
    }
}
