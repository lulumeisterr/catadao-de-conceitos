using System.Text.Json;
using Application.Data.NegocioDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;


namespace QueryHandler.Application.Query
{
    /// <summary>
    /// Classe de consulta
    /// </summary>
    public class ConsultarTodosNegocios : IQueryHandler<NegocioCommandResponse>
    {
        private readonly NegocioDbContext _negocioDbContext;
        private readonly IDistributedCache _redisCache;
        private const string GetCacheRedis = "AllTrades";

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="applicationDbContext">Contexto</param>
        public ConsultarTodosNegocios(NegocioDbContext applicationDbContext, IDistributedCache cache)
        {
            this._negocioDbContext = applicationDbContext ?? throw new ArgumentException(nameof(applicationDbContext)); ;
            this._redisCache = cache ?? throw new ArgumentException(nameof(cache));
        }

        /// <summary>
        /// Metodo responsavel por obter todos os registros de Negocio
        /// </summary>
        /// <returns>Lista de negocio</returns>
        public async Task<List<NegocioCommandResponse>> ConsultarTodosNegociosQueryHandler()
        {
            string? resultCache = await _redisCache.GetStringAsync(GetCacheRedis);
            if (String.IsNullOrEmpty(resultCache)) 
            {
                List<Negocio> result = await _negocioDbContext.Negocio.ToListAsync();

                if (result == null)
                    return null;

                List<NegocioCommandResponse> resulToResponse = result.Select(neg => new NegocioCommandResponse
                {
                    NomeNegociante = neg.NomeNegociante,
                    NumeroNegociacao = neg.NumeroNegociacao,
                    StatusNegociacao = neg.StatusNegociacao
                }).ToList();
                await _redisCache.SetStringAsync(GetCacheRedis, JsonSerializer.Serialize(resulToResponse));
                return resulToResponse;
            } else
            {
                return JsonSerializer.Deserialize<List<NegocioCommandResponse>>(resultCache);
            }
            return null;
        }
    }
}
