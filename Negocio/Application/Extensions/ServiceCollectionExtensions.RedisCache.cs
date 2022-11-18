using Microsoft.Extensions.Configuration;

namespace Application.Extensions.RedisCache
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("redis");
                options.InstanceName = "RedisTest";
            });
            return services;
        }
    }
}
