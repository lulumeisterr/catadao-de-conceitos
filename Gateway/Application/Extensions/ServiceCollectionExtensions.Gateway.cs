

using Ocelot.Provider.Consul;

namespace GatewayAPI.Application.Extensions.Ocelot
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Esse ocelot.json é onde você especifica todos os reencaminhamentos do Gateway de API, 
        /// o que significa os pontos de extremidade externos com portas específicas.
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="configuration">configuration</param>
        /// <returns>builder</returns>
        public static WebApplicationBuilder AddOcelotConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Services
                .AddOcelot()
                .AddConsul();
            return builder;
        }
    }
}
