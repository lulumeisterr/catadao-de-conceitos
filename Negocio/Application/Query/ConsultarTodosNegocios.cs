using Application.Data.NegocioDbContext;
using Microsoft.EntityFrameworkCore;
using Query.Application.Query.Interfaces;

namespace QueryHandler.Application.Query
{
    /// <summary>
    /// Classe de consulta
    /// </summary>
    public class ConsultarTodosNegocios : IQueryHandler<NegocioCommandResponse>
    {
        private readonly NegocioDbContext _negocioDbContext;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="applicationDbContext">Contexto</param>
        public ConsultarTodosNegocios(NegocioDbContext applicationDbContext)
        {
            this._negocioDbContext = applicationDbContext;
        }

        /// <summary>
        /// Metodo responsavel por obter todos os registros de Negocio
        /// </summary>
        /// <returns>Lista de negocio</returns>
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
