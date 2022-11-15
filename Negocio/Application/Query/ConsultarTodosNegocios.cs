using Application.Data.NegocioDbContext;
using Microsoft.EntityFrameworkCore;
using Query.Application.Query.Interfaces;

namespace QueryHandler.Application.Query
{
    public class ConsultarTodosNegocios : IQueryHandler<NegocioCommandResponse>
    {
        private readonly NegocioDbContext _negocioDbContext;

        public ConsultarTodosNegocios(NegocioDbContext applicationDbContext)
        {
            this._negocioDbContext = applicationDbContext;
        }
        public async Task<List<NegocioCommandResponse>> ConsultarTodosNegociosQueryHandler()
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

            return resulToResponse;
        }
    }
}
