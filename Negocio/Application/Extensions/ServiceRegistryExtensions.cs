using System;
using Consul;

namespace Application.Extensions.Registry
{
    public static partial class ServiceRegistryExtensions
    {
        //Configurando a inicialização do consul responsavel por registar o servil que sera registrado no consul dentro do api gateway
        public static IServiceCollection AddConsulSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(c => new ConsulClient(config =>
            {
                config.Address = new Uri(configuration.GetSection("Service")["Address"]);
            }));
            return services;
        }

        //Consumindo as informações de configuração do service
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            IConsulClient consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            IHostApplicationLifetime lifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            ILogger logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("ConsulExtensions");

            AgentServiceRegistration agentRegistration = new AgentServiceRegistration()
            {
                ID = configuration.GetSection("Service")["ID"],
                Name = configuration.GetSection("Service")["Name"],
                Address = configuration.GetSection("Service")["Host"],
                Port = Int32.Parse(configuration.GetSection("Service")["Port"])
            };

            logger.LogInformation("Registrando servico");
            consulClient.Agent.ServiceDeregister(agentRegistration.ID).ConfigureAwait(true); //Desregistrando caso ja exista
            consulClient.Agent.ServiceRegister(agentRegistration).ConfigureAwait(true); // Registrando servico

            lifeTime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation($"Servico {agentRegistration.ID} inativo");

                /**
                 *  implementar healthcheck para remover os servicos
                string url = $"http://{configuration.GetSection("Service")["Host"]}:{Int32.Parse(configuration.GetSection("Service")["Port"])}";
                var client = new HttpClient { BaseAddress = new Uri(url) };
                var response = client.PutAsync($"/v1/agent/service/deregister/{agentRegistration.ID}", null).Result;

                if (response.IsSuccessStatusCode)
                {
                    logger.LogInformation("Servico descadastrado");
                }
                **/
            });
            return app;
        }
    }
}
