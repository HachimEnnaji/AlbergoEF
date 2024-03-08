using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicazione1.Models
{
    public class Prenotazione
    {
        [Key]
        public int IdPrenotazione { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [Required]
        [ForeignKey("Camera")]
        public int IdCamera { get; set; }

        [Required]
        [ForeignKey("Pensione")]
        public int IdPensione { get; set; }

        [Required]
        public DateTime DataInizio { get; set; }
        [Required]
        public DateTime DataFine { get; set; }
        [Required]
        public double Acconto { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Camera Camera { get; set; }
        public virtual Pensione Pensione { get; set; }
        public virtual ICollection<Servizio> Servizi { get; set; }
    }
}
