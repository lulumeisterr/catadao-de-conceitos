namespace Domain.Models
{
    /// <summary>
    /// Classe de negociacao
    /// </summary>
    public class Negociacao
    {
        public int NumeroNegociacao { get; set; }
        public string NomeNegociante { get; set; }
        public bool StatusNegociacao { get; set; }

        /// <summary>
        /// Construtor de negociacao
        /// </summary>
        /// <param name="numeroNegociacao">Numero da negociacao</param>
        /// <param name="nomeNegociante">Nome do negociante</param>
        /// <param name="statusNegociacao">status da negociação</param>
        public Negociacao(int numeroNegociacao, string nomeNegociante, bool statusNegociacao)
        {
            NumeroNegociacao = numeroNegociacao;
            NomeNegociante = nomeNegociante;
            StatusNegociacao = statusNegociacao;
        }

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Negociacao()
        {
        }
    }
}
