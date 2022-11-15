namespace Application.Command.Interface.IHandler
{
    public interface IHandler<RequestCommandHandler,ResponseCommandHandler>
    {
        Task<ResponseCommandHandler> Handler(RequestCommandHandler request);
    }
}
