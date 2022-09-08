namespace Application.ViewModel.response
{
    /// <summary>
    /// Herdando atributos da classe abstrata para criar referencias
    /// de validação utilizando Fluent Validator
    /// </summary>
    public class NegociationCommandResponse : NegociationDTO
    {
        public NegociationCommandResponse()
        {
        }

        public NegociationCommandResponse(int numeroNegociacao, string nomeNegociante, bool statusNegociacao)
        {
            NumeroNegociacao = numeroNegociacao;
            NomeNegociante = nomeNegociante;
            StatusNegociacao = statusNegociacao;
        }
    }
}
