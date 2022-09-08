using Domain.CommandHandler.Interface;
using Domain.Commands;

namespace Domain.CommandHandler.Handlers
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
    public class NegociationCommandHandler : IHandler<NegociationCommandResponse,NegociationCommandRequest>
    {
        public Task<NegociationCommandResponse> Handler(NegociationCommandRequest request)
        {
            if (!request.IsValid())
                return null;

            return Task.FromResult(new NegociationCommandResponse(request.NumeroNegociacao, request.NomeNegociante, request.StatusNegociacao)); ;
        }
    }
}
