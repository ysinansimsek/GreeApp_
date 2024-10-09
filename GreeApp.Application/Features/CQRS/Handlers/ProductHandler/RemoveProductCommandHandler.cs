using GreeApp.Application.Features.CQRS.Commands.ProductCommand;
using GreeApp.Application.Interfaces;
using GreeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Handlers.ProductHandler
{
    public class RemoveProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveProductCommand command)
        {
           var value =await  _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
