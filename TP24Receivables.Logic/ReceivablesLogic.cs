using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Classes;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic
{
    public class ReceivablesLogic
    {
        private IStatisticsConfig statisticsConfig;
        private List<Debtor> Debtors { get; set; }

        public ReceivablesLogic(List<Debtor> debtors, IStatisticsConfig config)
        {
            this.Debtors = debtors;
            this.statisticsConfig = config;
        }

        public List<Statistics> GetStatisticsForAllDebtors()
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
            var late = GetLateReceivables(open);
            var dueIn7Days = GetDueIn7DaysReceivables(open);

            var metricBuilder = new MetricBuilder(debtor.Receivables, statisticsConfig);

            return new Statistics()
            {
                DebtorReference = debtor.Reference,
                DebtorName = debtor.Name,
                CurrencyCode = statisticsConfig.CurrencyCode,

                All = metricBuilder.BuildMetric(debtor.Receivables),

                Cancelled = metricBuilder.BuildMetric(cancelled),

                Open = metricBuilder.BuildMetric(open),
                Late = metricBuilder.BuildMetric(late),
                DueIn7Days = dueIn7Days.Count,

                Closed = metricBuilder.BuildMetric(closedReceivables),
                ClosedLate = closedLate.Count,
            };
        }


        private List<Receivable> GetCancelledReceivables(List<Receivable> receivables)
        {
            return receivables.Where(receivable => 
                receivable.Cancelled != null && 
                receivable.Cancelled == true
            ).ToList();
        }

        private List<Receivable> GetClosedReceivables(List<Receivable> receivables)
        {
            DateTime now = DateTime.Now;

            return receivables.Where(receivable => 
                receivable.ClosedDate != null &&
                receivable.ClosedDate.Value.Date <= now.Date && 
                receivable.PaidValue == receivable.OpeningValue
            ).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="closedReceivables"></param>
        /// <returns></returns>
        private List<Receivable> GetClosedLateReceivables(List<Receivable> closedReceivables)
        {
            return closedReceivables.Where(receivables => 
                receivables.DueDate.Date < receivables.ClosedDate.Value.Date
            ).ToList();
        }

        private List<Receivable> GetDueIn7DaysReceivables(List<Receivable> openReceivables)
        {
            DateTime now = DateTime.Now;

            return openReceivables.Where(
                receivables => (receivables.DueDate - now).TotalDays <= 7
            ).ToList();
        }

        private List<Receivable> GetLateReceivables(List<Receivable> openReceivables)
        {
            DateTime now = DateTime.Now;

            return openReceivables.Where(
                receivables => receivables.DueDate.Date < now.Date
            ).ToList();
        }
    }
}