namespace Applicazione1.Data
{
    public static class TipoCamera
    {
        public const string StandardSingola = "Standard Singola";
        public const string StandardMatrimoniale = "Standard Matrimoniale";
        public const string DeluxeSingola = "Deluxe Singola";
        public const string DeluxeMatrimoniale = "Deluxe Matrimoniale";
        public const string PremiumSingola = "Premium Singola";
        public const string PremiumMatrimoniale = "Premium Matrimoniale";
        public const string Suite = "Suite";

        public static IEnumerable<string> ListaCamere = new List<string>
        {
            StandardSingola,
            StandardMatrimoniale,
            DeluxeSingola,
            DeluxeMatrimoniale,
            PremiumSingola,
            PremiumMatrimoniale,
            Suite
        };

    }
}
