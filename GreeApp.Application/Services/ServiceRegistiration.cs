using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void Register(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddMediatR(con => con.RegisterServicesFromAssembly(typeof (ServiceRegistiration).Assembly));
        }
    }
}
