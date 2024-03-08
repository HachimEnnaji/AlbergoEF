using System.ComponentModel.DataAnnotations;

namespace Applicazione1.Models
{
    public class Pensione
    {
        [Key]
        public int IdPensione { get; set; }
        public string Tipo { get; set; }
        public double Costo { get; set; }

        public virtual Prenotazione Prenotazione { get; set; }
    }
}
