using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Data.Model.Negocio
{
    /// <summary>
    /// Classe de negociacao
    /// </summary>
     [Table("Negocio")]
    public class Negocio
    {
        [Key]
        [Required]
        public int NumeroNegociacao { get; set; }
        [Required]
        public string NomeNegociante { get; set; }
        [Required]
        public bool StatusNegociacao { get; set; }

        /// <summary>
        /// Construtor de negociacao
        /// </summary>
        /// <param name="numeroNegociacao">Numero da negociacao</param>
        /// <param name="nomeNegociante">Nome do negociante</param>
        /// <param name="statusNegociacao">status da negociação</param>
        public Negocio(int numeroNegociacao, string nomeNegociante, bool statusNegociacao)
        {
            NumeroNegociacao = numeroNegociacao;
            NomeNegociante = nomeNegociante;
            StatusNegociacao = statusNegociacao;
        }

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Negocio()
        {
        }
    }
}
