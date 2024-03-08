namespace Applicazione1.Data
{
    public class TipoServizio
    {
        public const string Trasporto = "Trasporto";
        public const string Spa = "Spa";
        public const string ServizioInCamera = "Servizio in camera";

        public static IEnumerable<string> ListaServizi = new List<string>
        {
            Trasporto,
            Spa,
            ServizioInCamera
        };
    }
}
