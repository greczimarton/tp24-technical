using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic.Classes
{
    internal class MetricBuilder
    {
        private readonly double allReceivablesCount;
        private readonly double allReceivablesValue;
        private readonly CurrencyConverter currencyConverter;
        private readonly int NumberOfDecimalDigitsConfig;

        internal MetricBuilder(List<Receivable> allReceivables, IStatisticsConfig config) 
        {
            this.currencyConverter = new CurrencyConverter(config);
            this.NumberOfDecimalDigitsConfig = config.NumberOfDecimalDigits;

            this.allReceivablesCount = allReceivables.Count;
            this.allReceivablesValue = ConvertReceivablesAndSum(allReceivables);
        }

        internal Metric BuildMetric(List<Receivable> receivables)
        {
            double value = ConvertReceivablesAndSum(receivables);

            return new Metric()
            { 
                Count = receivables.Count,
                CountRate = Math.Round(Convert.ToDouble(receivables.Count) / Convert.ToDouble(allReceivablesCount), NumberOfDecimalDigitsConfig),
                Value = value,
                ValueRate = Math.Round(value / allReceivablesValue, NumberOfDecimalDigitsConfig),
            };
        }

        private double ConvertReceivablesAndSum(List<Receivable> receivables)
        {
            var sum = receivables.Select(receivable => 
                currencyConverter.Convert(receivable.OpeningValue, receivable.CurrencyCode)
            ).Sum();
            var rounded = Math.Round(sum, NumberOfDecimalDigitsConfig);

            return rounded;
        }
    }
}
