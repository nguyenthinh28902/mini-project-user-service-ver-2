using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces.Services;
using UserService.Core.Abstractions.Persistence;
using UserService.Core.Entities;
using UserService.Infrastructure.Dbcontext;
using UserService.Infrastructure.Persistence;
using UserService.Infrastructure.Services;

namespace UserService.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging() //ghi log các câu truy vấn SQL và thông tin nhạy cảm

                );
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<UserDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserValidationService, UserValidationService>();
            services.AddScoped<IUserManagerService, UserManagerService>();

            return services;
        }
    }
}
