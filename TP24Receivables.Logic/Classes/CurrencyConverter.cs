using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic.Classes
{
    public class CurrencyConverter
    {
        public IStatisticsConfig Config { get; set; }
        public CurrencyConverter(IStatisticsConfig config)
        {
            Config = config;
        }

        public double Convert(double inputValue, string inputCurrencyCode)
        {
            if (inputCurrencyCode == null || !Config.SupportedCurrencies.ContainsKey(inputCurrencyCode))
            {
                return 0;
            }

            double exchangeRate = Config.SupportedCurrencies[inputCurrencyCode];

            return inputValue * exchangeRate;
        }
    }
}
