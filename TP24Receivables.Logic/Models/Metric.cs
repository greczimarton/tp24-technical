using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Logic.Models
{
    public class Metric
    {
        public int Count { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }

        public Metric(List<Receivable> receivables, double allReceivablesCount, CurrencyConverter currencyConverter)
        {
            this.Count = receivables.Count;
            this.Rate = Convert.ToDouble(receivables.Count) / Convert.ToDouble(allReceivablesCount);
            this.Value = ConvertReceivablesAndSum(receivables, currencyConverter);
        }

        private double ConvertReceivablesAndSum(List<Receivable> receivables, CurrencyConverter currencyConverter)
        {
            return receivables.Select(receivable => currencyConverter.Convert(receivable.OpeningValue, receivable.CurrencyCode)).Sum();
        }
    }
}
