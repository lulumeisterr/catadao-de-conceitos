namespace Query.Application.Query.Interfaces
{
    public interface IQueryHandler<ResponseCommandHandler>
    {
        /// <summary>
        /// Metodo responsavel por obter todos os registros de Negocio
        /// </summary>
        /// <returns>Lista de negocio</returns>
        Task<List<NegocioCommandResponse>> ConsultarTodosNegociosQueryHandler();
    }
}
