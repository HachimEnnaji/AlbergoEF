namespace Applicazione1.Data
{
    public class TipoPensione
    {
        public const string SoloPernottamento = "Solo Pernottamento";
        public const string Colazione = "Colazione";
        public const string MezzaPensione = "Mezza Pensione";
        public const string PensioneCompleta = "Pensione Completa";

        public static IEnumerable<string> ListaPensioni = new List<string>
        {
            SoloPernottamento,
            Colazione,
            MezzaPensione,
            PensioneCompleta
        };
    }
}
