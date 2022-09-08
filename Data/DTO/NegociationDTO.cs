namespace Domain.Models
{
    public abstract class NegociationDTO
    {
        public int NumeroNegociacao { get; set; }
        public string NomeNegociante { get; set; }
        public bool StatusNegociacao { get; set; }
    }
}
