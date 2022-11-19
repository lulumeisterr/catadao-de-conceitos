namespace Query.Application.Query.Interfaces
{
    public interface IQueryHandler<ResponseCommandHandler>
    {
        /// <summary>
        /// Metodo responsavel por obter todos os registros dos servidores cadastrados
        /// </summary>
        /// <returns>Lista de negocio</returns>
        Task<List<ServerCommandResponse>> ConsultarTodosServersQueryHandler();
    }
}
