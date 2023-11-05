using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Logic
{
    internal class CurrencyConverter
    {
        public StatisticsConfig Config {  get; set; }
        public CurrencyConverter(StatisticsConfig config) 
        {
            this.Config = config;
        }

        public double Convert(double inputValue, string inputCurrencyCode)
        {
            if (!Config.SupportedCurrencies.ContainsKey(inputCurrencyCode)) 
            {
                return 0;
            }

            double exchangeRate = Config.SupportedCurrencies[inputCurrencyCode];

            return inputValue * exchangeRate;
        }
    }
}
