using Domain.Commands.Intefaces;
using Domain.Commands.Validators;
using Domain.Models;
using FluentValidation.Results;

namespace Domain.Commands
{
    /// <summary>
    /// Herdando atributos da classe abstrata para criar referencias
    /// de validação utilizando Fluent Validator
    /// </summary>
    public class NegociationCommandRequest : NegociationDTO, ICommandIsValid
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="numeroNegociacao"></param>
        /// <param name="nomeNegociante"></param>
        /// <param name="statusNegociacao"></param>
        public NegociationCommandRequest(int numeroNegociacao, string nomeNegociante, bool statusNegociacao)
        {
            NumeroNegociacao = numeroNegociacao;
            NomeNegociante = nomeNegociante;
            StatusNegociacao = statusNegociacao;
        }

        /// <summary>
        /// Metodo responsavel por verificar se existe valores errados no objeto de negociação
        /// </summary>
        /// <returns>Retorna se os dados estao integros</returns>
        public bool IsValid()
        {
            ValidationResult validationResult = new NegociationValidator().Validate(this);
            return validationResult.IsValid;
        }
    }
}
