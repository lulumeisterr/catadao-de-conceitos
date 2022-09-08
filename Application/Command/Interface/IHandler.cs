namespace Application.Command.Interface.IHandler
{
    public interface IHandler<ResponseCommandHandler,RequestCommandHandler>
    {
        Task<ResponseCommandHandler> Handler(RequestCommandHandler request);
    }
}
