namespace Query.Application.Query.Interfaces
{
    public interface IQueryHandler<ResponseCommandHandler>
    {
        Task<List<NegocioCommandResponse>> ConsultarTodosNegociosQueryHandler();
    }
}
