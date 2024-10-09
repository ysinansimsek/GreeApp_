﻿using GreeApp.Application.Features.CQRS.Commands.ItemProductCommand;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.ItemProductHandler
{
    public class UpdateItemProductCommandHandler
    {
        private readonly IRepository<ItemProduct> _repository;

        public UpdateItemProductCommandHandler(IRepository<ItemProduct> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateItemProductCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            //values.Description = command.Description;
            //values.Name = command.Name;
            //values.Barcode = command.Barcode;
            await _repository.UpdateAsync(values);
        }
    }
}
