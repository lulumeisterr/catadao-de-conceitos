namespace Application.ViewModel
{
    public abstract class NegocioDTO
    {
        public int NumeroNegociacao { get; set; }
        public string NomeNegociante { get; set; }
        public bool StatusNegociacao { get; set; }
    }
}
