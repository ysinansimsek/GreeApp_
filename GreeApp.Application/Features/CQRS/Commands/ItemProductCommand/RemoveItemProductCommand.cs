using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Commands.ItemProductCommand
{
    public class RemoveItemProductCommand
    {
        public int Id { get; set; }

        public RemoveItemProductCommand(int id)
        {
            Id = id;
        }
    }
}
