using GreeApp.Application.Features.CQRS.Commands.ItemProductCommand;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.ItemProductHandler
{
    public class CreateItemProductCommandHandler
    {
        private readonly IRepository<ItemProduct> _repository;

        public CreateItemProductCommandHandler(IRepository<ItemProduct> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateItemProductCommand command)
        {
            await _repository.CreateAsync(new ItemProduct
            {
                //Name = command.Name,
                //Description = command.Description,
                //Barcode = command.Barcode,
                //Brand = command.Brand,
            });
        }
    }
}
