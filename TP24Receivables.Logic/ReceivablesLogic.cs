using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic
{
    public class ReceivablesLogic
    {
        private CurrencyConverter CurrencyConverter;
        private List<Receivable> Receivables { get; set; }

        public ReceivablesLogic(List<Receivable> receivables, StatisticsConfig config)
        {
            this.Receivables = receivables;
            this.CurrencyConverter = new CurrencyConverter(config);
        }

        public StatisticsDto GetStatistics()
        {
            var cancelledReceivables = GetCancelledReceivables(Receivables);
            var closedReceivables = GetClosedReceivables(Receivables.Except(cancelledReceivables).ToList());
            var openReceivables = Receivables.Except(closedReceivables).ToList();

            return new StatisticsDto()
            {
                CurrencyCode = this.CurrencyConverter.Config.CurrencyCode,

                CancelledReceivables = cancelledReceivables.Count,
                CancellationRate = cancelledReceivables.Count / Receivables.Count,

                OpenReceivables = openReceivables.Count,
                OpenReceivablesValue = ConvertReceivablesAndSum(openReceivables),
                OpenRate = openReceivables.Count / Receivables.Count,

                ClosedReceivables = closedReceivables.Count,
                ClosedReceivablesValue = ConvertReceivablesAndSum(closedReceivables),
                ClosedRate = closedReceivables.Count / Receivables.Count,
            };
        }

        private List<Receivable> GetCancelledReceivables(List<Receivable> receivables)
        {
            return receivables.Where(receivable => receivable.Cancelled != null && receivable.Cancelled == true).ToList();
        }

        private List<Receivable> GetClosedReceivables(List<Receivable> receivables)
        {
            return receivables.Where(receivable => receivable.ClosedDate != null && receivable.PaidValue == receivable.OpeningValue).ToList();
        }

        private double ConvertReceivablesAndSum(List<Receivable> receivables)
        {
            return receivables.Select(receivable => CurrencyConverter.Convert(receivable.OpeningValue, receivable.CurrencyCode)).Sum();
        }
    }
}