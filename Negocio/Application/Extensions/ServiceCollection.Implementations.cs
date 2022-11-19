namespace Application.Extensions.Server
{
    public static partial class ServiceCollection
    {
        public static IServiceCollection AddDependenciesBusinessObject (this IServiceCollection services)
        {
            services.AddScoped<IHandler<ServerCommandRequest, ServerCommandResponse>, ServerCommandHandler>();
            services.AddScoped<IQueryHandler<ServerCommandResponse>, ConsultarTodosServers>();
            return services;
        }
    }
}
