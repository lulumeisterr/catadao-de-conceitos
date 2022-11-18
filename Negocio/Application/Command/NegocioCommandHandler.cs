using Application.Data.NegocioDbContext;
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
    public class NegocioCommandHandler : IHandler<NegociationCommandRequest,NegocioCommandResponse>
    {
        private readonly NegocioDbContext negocioDbContext;
        private readonly IDistributedCache _redisCache;
        private const string GetCacheRedis = "AllTrades";

        public NegocioCommandHandler(NegocioDbContext applicationDbContext, IDistributedCache cache)
        {
            this.negocioDbContext = applicationDbContext;
            this._redisCache = cache ?? throw new ArgumentException(nameof(cache));
        }
        public Task<NegocioCommandResponse> Handler(NegociationCommandRequest request)
        {
            if (!request.IsValid())
                return null;

            //Construir um automapper para a camada de request
            Negocio negocio = new();
            negocio.NomeNegociante = request.NomeNegociante;
            negocio.StatusNegociacao = request.StatusNegociacao;
            negocio.NumeroNegociacao = request.NumeroNegociacao;

            negocioDbContext.Add(negocio);
            negocioDbContext.SaveChanges();
            _redisCache.Remove(GetCacheRedis);

            return Task.FromResult(new NegocioCommandResponse(request.NumeroNegociacao, request.NomeNegociante, request.StatusNegociacao)); ;
        }
    }
}
