namespace TP24Receivables.Logic.Models
{
    public class StatisticsConfig : IStatisticsConfig
    {
        public string CurrencyCode { get; set; }
        public Dictionary<string, double> SupportedCurrencies { get; set; }
        public int NumberOfDecimalDigits { get; set; }
    }
}
