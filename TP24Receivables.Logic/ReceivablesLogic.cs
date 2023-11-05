using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic
{
    public class ReceivablesLogic
    {
        private CurrencyConverter CurrencyConverter;
        private List<Debtor> Debtors { get; set; }

        public ReceivablesLogic(List<Debtor> debtors, StatisticsConfig config)
        {
            this.Debtors = debtors;
            this.CurrencyConverter = new CurrencyConverter(config);
        }

        public List<Statistics> GetStatisticsForAllReceivables()
        {
            var allStatistics = new List<Statistics>();

            foreach (var debtor in Debtors)
            {
                var statisticsForDebtor = GetStatisticsForDebtor(debtor);
                allStatistics.Add(statisticsForDebtor);
            }

            return allStatistics;
        }

        public Statistics GetStatisticsForDebtor(Debtor debtor) 
        {
            var cancelled = GetCancelledReceivables(debtor.Receivables);

            var remaining = debtor.Receivables.Except(cancelled).ToList();
            var closedReceivables = GetClosedReceivables(remaining);
            var closedLate = GetClosedLateReceivables(closedReceivables);
            var open = remaining.Except(closedReceivables).ToList();
            var dueIn7Days = GetDueIn7DaysReceivables(closedReceivables);

            return new Statistics()
            {
                DebtorReference = debtor.Reference,
                DebtorName = debtor.Name,
                CurrencyCode = this.CurrencyConverter.Config.CurrencyCode,
                NumberOfReceivables = debtor.Receivables.Count,

                Cancelled = new Metric(cancelled, debtor.Receivables.Count, CurrencyConverter),
                Open = new Metric(open, debtor.Receivables.Count, CurrencyConverter),
                DueIn7Days = dueIn7Days.Count,
                Closed = new Metric(closedReceivables, debtor.Receivables.Count, CurrencyConverter),
                ClosedLate = closedLate.Count,
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
        private List<Receivable> GetClosedLateReceivables(List<Receivable> closedReceivables)
        {
            return closedReceivables.Where(receivables => receivables.ClosedDate < receivables.DueDate).ToList();
        }
        private List<Receivable> GetDueIn7DaysReceivables(List<Receivable> closedReceivables)
        {
            DateTime now = DateTime.Now;
            return closedReceivables.Where(receivables => (receivables.DueDate - now).TotalDays < 7).ToList();
        }
    }
}