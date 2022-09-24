using Microsoft.OpenApi.Models;

namespace Application.Extensions.OpenAPI
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddOpenAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();
            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "API - Teste",
                    Title = "API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Rodrigues",
                        Email = "lucasrodriguesdonascimento@outlook.com"
                    }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseOpenSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Negocio");
            });
            return app;
        }
    }
}