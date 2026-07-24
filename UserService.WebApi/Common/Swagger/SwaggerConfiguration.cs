using Microsoft.OpenApi.Models;

namespace UserService.WebApi.Common.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerInfrastructure(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            //thêm cấu hình Swagger Auth (Bearer JWT)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "Idenity User Service",
                    Version = "v1"
                });

                // 🔐 JWT Bearer config

                //c.OperationFilter<AllowAnonymousOperationFilter>();
            });
            return services;
        }
    }
}
