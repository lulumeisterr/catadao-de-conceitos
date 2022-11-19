using ServerValueObject.Application.ViewModel.ValueObject;
namespace Application.ViewModel.response
{
    /// <summary>
    /// Herdando atributos da classe abstrata para criar referencias
    /// de validação utilizando Fluent Validator
    /// </summary>
    public class ServerCommandResponse : ServerVO
    {
        public ServerCommandResponse()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="ip">Ip do servidor</param>
        /// <param name="porta">Porta do servidor</param>
        /// <param name="nome">Nome do servidor</param>
        public ServerCommandResponse(string ip, string porta, string nome)
        {
            Ip = ip;
            Porta = porta;
            Nome = nome;
        }
    }
}
