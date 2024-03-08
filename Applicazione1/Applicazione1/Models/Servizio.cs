using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicazione1.Models
{
    public class Servizio
    {
        [Key]
        public int IdServizio { get; set; }
        [Required]
        [ForeignKey("Prenotazione")]
        public int IdPrenotazione { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public double Costo { get; set; }

        public virtual Prenotazione Prenotazione { get; set; }
    }
}
