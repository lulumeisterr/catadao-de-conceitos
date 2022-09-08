using Domain.CommandHandler.Handlers;

namespace Domain.CommandHandler.Interface
{
    public interface IHandler<ResponseCommandHandler,RequestCommandHandler>
    {
        Task<ResponseCommandHandler> Handler(RequestCommandHandler request);
    }
}
