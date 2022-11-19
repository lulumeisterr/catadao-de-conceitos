using System.Text.Json;
using Application.Data.ConfigureDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace QueryHandler.Application.Query
{
    /// <summary>
    /// Classe de consulta
    /// </summary>
    public class ConsultarTodosServers : IQueryHandler<ServerCommandResponse>
    {
        private readonly ServerDbContext _serverContext;
        private readonly IDistributedCache _redisCache;
        private const string GetCacheRedis = "AllServers";

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="applicationDbContext">Contexto</param>
        public ConsultarTodosServers(ServerDbContext applicationDbContext, IDistributedCache cache)
        {
            this._serverContext = applicationDbContext ?? throw new ArgumentException(nameof(applicationDbContext)); ;
            this._redisCache = cache ?? throw new ArgumentException(nameof(cache));
        }

        /// <summary>
        /// Metodo responsavel por obter todos os registros de Negocio
        /// </summary>
        /// <returns>Lista de negocio</returns>
        public async Task<List<ServerCommandResponse>> ConsultarTodosServersQueryHandler()
        {
            string? resultCache = await _redisCache.GetStringAsync(GetCacheRedis);
            if (String.IsNullOrEmpty(resultCache)) 
            {
                List<Server> result = await _serverContext.Server.ToListAsync();

                if (result == null)
                    return null;

                List<ServerCommandResponse> resulToResponse = result.Select(neg => new ServerCommandResponse
                {
                    Ip = neg.Ip,
                    Nome = neg.Nome,
                    Porta = neg.Porta
                }).ToList();
                await _redisCache.SetStringAsync(GetCacheRedis, JsonSerializer.Serialize(resulToResponse));
                return resulToResponse;
            } else
            {
                return JsonSerializer.Deserialize<List<ServerCommandResponse>>(resultCache);
            }
            return null;
        }
    }
}
