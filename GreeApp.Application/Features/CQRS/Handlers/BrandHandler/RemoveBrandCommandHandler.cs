﻿using GreeApp.Application.Features.CQRS.Commands.BrandCommand;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.BrandHandler
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
           var value =await  _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
