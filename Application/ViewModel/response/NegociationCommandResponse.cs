namespace Application.ViewModel.response
{
    /// <summary>
    /// Herdando atributos da classe abstrata para criar referencias
    /// de validação utilizando Fluent Validator
    /// </summary>
    public class NegocioCommandResponse : NegocioDTO
    {
        public NegocioCommandResponse()
        {
        }

        public NegocioCommandResponse(int numeroNegociacao, string nomeNegociante, bool statusNegociacao)
        {
            NumeroNegociacao = numeroNegociacao;
            NomeNegociante = nomeNegociante;
            StatusNegociacao = statusNegociacao;
        }
    }
}
