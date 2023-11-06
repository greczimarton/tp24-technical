using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TP24Receivables.Logic.Models;

namespace TP24Receivables.Test.TestData
{
    public class TestSetup
    {
        public static IStatisticsConfig CreateMockStatisticsConfig()
        {
            var configMock = new Mock<IStatisticsConfig>();
            configMock.Setup(c => c.CurrencyCode).Returns("EUR");
            configMock.Setup(c => c.SupportedCurrencies).Returns(new Dictionary<string, double>
            {
                { "USD", 0.93 },
                { "EUR", 1.0 },
                { "GBP", 1.15 },
                { "CHF", 1.04 }
            });
            configMock.Setup(c => c.NumberOfDecimalDigits).Returns(2);


            return configMock.Object;
        }
    }
}
