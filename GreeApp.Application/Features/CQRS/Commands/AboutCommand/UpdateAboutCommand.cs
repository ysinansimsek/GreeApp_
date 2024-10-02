using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Commands.AboutCommand
{
    public class UpdateAboutCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
