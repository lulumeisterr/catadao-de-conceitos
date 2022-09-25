
using Application.ViewModel.NegociacaoRequest;
using FluentValidation;

namespace Application.Validations.NegociacaoRequest
{
    /// <summary>
    /// Classe responsavel por receber um tipo generico para auto validar os atributos.
    /// </summary>
    /// <typeparam name="T">Espera um tipo Negociacao</typeparam>
    public class NegocioValidator : AbstractValidator<NegociationCommandRequest>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public NegocioValidator()
        {
            ValidateNegociationNumber();
            ValidateNegociationName();
            ValidateNegociationStatus();
        }

        /// <summary>
        /// Metodo responsavel por validar numero da negociacao
        /// </summary>
        public void ValidateNegociationNumber()
        {
            RuleFor(n => n.NumeroNegociacao)
                .NotNull().WithMessage("Atributo não pode ser nulo");
        }

        /// <summary>
        /// Metodo responsavel por validar nome da negociacao
        /// </summary>
        public void ValidateNegociationName()
        {
            RuleFor(n => n.NomeNegociante)
                .NotNull().WithMessage("Atributo não pode ser nulo").Length(1, 255).WithMessage("Atributo precisa ter entre 1 e 255 caracters");
        }

        /// <summary>
        /// Metodo responsavel por validar status da negociacao
        /// </summary>
        public void ValidateNegociationStatus()
        {
            RuleFor(n => n.StatusNegociacao)
                .NotNull().WithMessage("Atributo não pode ser nulo");
        }
    }
}
