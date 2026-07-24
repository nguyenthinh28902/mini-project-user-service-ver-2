using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Mappings;

namespace UserService.Application.DependencyInjection
{
    public static class MappingService
    {
        public static IServiceCollection AddMappingService(this IServiceCollection services)
        {

            services.AddAutoMapper(cfg => {

                cfg.AddProfile<UserProfile>();
            });
            return services;
        }
    }
}
