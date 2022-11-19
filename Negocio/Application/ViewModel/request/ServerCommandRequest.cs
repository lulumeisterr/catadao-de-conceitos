using Application.Command.Interface;
using Application.Validations.ServerValidator;
using FluentValidation.Results;
using ServerValueObject.Application.ViewModel.ValueObject;

namespace Application.ViewModel.NegociacaoRequest
{
    /// <summary>
    /// Herdando atributos da classe abstrata para criar referencias
    /// de validação utilizando Fluent Validator
    /// </summary>
    public class ServerCommandRequest : ServerVO, ICommandIsValid
    {

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="ip">Ip do servidor</param>
        /// <param name="porta">Porta do servidor</param>
        /// <param name="nome">Nome do servidor</param>
        public ServerCommandRequest(string ip, string porta, string nome)
        {
            Ip = ip;
            Porta = porta;
            Nome = nome;
        }

        /// <summary>
        /// Metodo responsavel por verificar se existe valores errados no objeto de server
        /// </summary>
        /// <returns>Retorna se os dados estao integros</returns>
        public bool IsValid()
        {
            ValidationResult validationResult = new ServerValidator().Validate(this);
            return validationResult.IsValid;
        }
    }
}
