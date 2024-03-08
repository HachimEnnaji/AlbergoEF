using System.ComponentModel.DataAnnotations;

namespace Applicazione1.Models
{
    public class Camera
    {
        [Key]
        public int IdCamera { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public double Costo { get; set; }
        public virtual Prenotazione Prenotazione { get; set; }

    }
}
