using System.ComponentModel.DataAnnotations;

namespace Applicazione1.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Citta { get; set; }
        public string Email { get; set; }
        public string Cellulare { get; set; }
        public virtual ICollection<Prenotazione> Prenotazioni { get; set; }


    }
}
