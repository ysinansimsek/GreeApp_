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
    public class RemoveItemProductCommandHandler
    {
        private readonly IRepository<ItemProduct> _repository;

        public RemoveItemProductCommandHandler(IRepository<ItemProduct> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveItemProductCommand command)
        {
           var value =await  _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
