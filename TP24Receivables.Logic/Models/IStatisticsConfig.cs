namespace TP24Receivables.Logic.Models
{
    public interface IStatisticsConfig
    {
        string CurrencyCode { get; set; }
        Dictionary<string, double> SupportedCurrencies { get; set; }
        int NumberOfDecimalDigits { get; set; }

    }
}