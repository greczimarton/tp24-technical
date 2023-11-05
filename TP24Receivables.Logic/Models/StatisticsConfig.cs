namespace TP24Receivables.Logic.Models
{
    public class StatisticsConfig
    {
        public string CurrencyCode { get; set; }
        public Dictionary<string, double> SupportedCurrencies { get; set; }
    }
}
