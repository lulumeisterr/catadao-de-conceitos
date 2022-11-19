using Application.Data.ConfigureDbContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Extensions.EFcore
{

    // Usando Partial Class com o objetivo de segmentar/separar pequenos pedaços de classe.  
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ServerDbContext>(opt => opt.UseMySql(configuration.GetConnectionString("SQL"),new MySqlServerVersion(new Version(8, 0, 27))));
            return services;
        }
    }

}