
using FluentValidation;

namespace Application.Validations.ServerValidator
{
    /// <summary>
    /// Classe responsavel por receber um tipo generico para auto validar os atributos.
    /// </summary>
    /// <typeparam name="T">Espera um tipo Server</typeparam>
    public class ServerValidator : AbstractValidator<ServerCommandRequest>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ServerValidator()
        {
            ValidateIpNumber();
            ValidateServerName();
            ValidatePort();
        }

        /// <summary>
        /// Metodo responsavel por validar o ip do servidor
        /// </summary>
        public void ValidateIpNumber()
        {
            RuleFor(n => n.Ip)
                .NotNull().WithMessage("Atributo não pode ser nulo");
        }

        /// <summary>
        /// Metodo responsavel por validar o nome do servidor
        /// </summary>
        public void ValidateServerName()
        {
            RuleFor(n => n.Nome)
                .NotNull().WithMessage("Atributo não pode ser nulo").Length(1, 255).WithMessage("Atributo precisa ter entre 1 e 255 caracters");
        }

        /// <summary>
        /// Metodo responsavel por validar a porta do servidor
        /// </summary>
        public void ValidatePort()
        {
            RuleFor(n => n.Porta)
                .NotNull().WithMessage("Atributo não pode ser nulo");
        }
    }
}
