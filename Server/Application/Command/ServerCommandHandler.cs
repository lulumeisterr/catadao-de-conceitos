﻿using Application.Data.ConfigureDbContext;
using Microsoft.Extensions.Caching.Distributed;

namespace Domain.Command.Handlers
{
    /**
     *  Responsavel por manipular tipos de comando que alteram o estado da entidade.
	    - Para cada command a ser implementado nos precisamos ter um Handler recebendo a requisição
	    - Verificamos se o comando é valido caso contrario devemos lançar uma notificação
	    - Apos validar o comando devemos receber ele em uma entidade
	    - Chamar o repositorio
	    - Realizar o commit, adicionar regras de validacao para que so seja commitado caso não tenha nenhum erro/notifications do fluent validator
	    - Retornar o status da gravação no banco caso contrario lancamos uma notificacao de erro.
     */
    public class ServerCommandHandler : IHandler<ServerCommandRequest,ServerCommandResponse>
    {
        private readonly ServerDbContext _serverContext;
        private readonly IDistributedCache _redisCache;
        private const string GetCacheRedis = "AllServers";

        public ServerCommandHandler(ServerDbContext applicationDbContext, IDistributedCache cache)
        {
            this._serverContext = applicationDbContext;
            this._redisCache = cache ?? throw new ArgumentException(nameof(cache));
        }
        public Task<ServerCommandResponse> Handler(ServerCommandRequest request)
        {
            if (!request.IsValid())
                return null;

            //Construir um automapper para a camada de request
            Server server = new();
            server.Ip = request.Ip;
            server.Nome = request.Nome;
            server.Porta = request.Porta;

            _serverContext.Add(server);
            _serverContext.SaveChanges();
            _redisCache.Remove(GetCacheRedis);

            return Task.FromResult(new ServerCommandResponse(request.Ip, request.Porta, request.Nome));
        }
    }
}
