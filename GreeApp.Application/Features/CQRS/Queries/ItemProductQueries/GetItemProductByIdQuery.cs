using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Features.CQRS.Queries.ItemProductQueries
{
    public class GetItemProductByIdQuery
    {
        public GetItemProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
