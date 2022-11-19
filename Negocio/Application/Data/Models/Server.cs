using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Data.Model.Server
{
    /// <summary>
    /// Classe de Server
    /// </summary>
     [Table("Server")]
    public class Server
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Ip { get; set; }
        [Required]
        public string Porta { get; set; }
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id">Indice</param>
        /// <param name="ip">Ip do servidor</param>
        /// <param name="porta">Porta do servidor</param>
        /// <param name="nome">Nome do servidor</param>
        public Server(int id, string ip, string porta, string nome)
        {
            Id = id;
            Ip = ip;
            Porta = porta;
            Nome = nome;
        }

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Server()
        {
        }
    }
}
