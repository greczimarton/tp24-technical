using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Models;
using TP24Receivables.Logic;
using TP24Receivables.Test.TestData.SortTestData;
using TP24Receivables.Test.TestData;
using TP24Receivables.Test.SortTestData;

namespace TP24Receivables.Test
{
    public class SumUnitTests
    {
        private readonly IStatisticsConfig mockStatisticsConfig;

        public SumUnitTests()
        {
            mockStatisticsConfig = TestSetup.CreateMockStatisticsConfig();
        }

        [Theory]
        [MemberData(nameof(DebtorSumTest_Cancelled.AllCancelled), MemberType = typeof(DebtorSumTest_Cancelled))]
        [MemberData(nameof(DebtorSumTest_Cancelled.HalfCancelled), MemberType = typeof(DebtorSumTest_Cancelled))]
        [MemberData(nameof(DebtorSumTest_Cancelled.NoneCancelled), MemberType = typeof(DebtorSumTest_Cancelled))]
        public void SumReceivables_Cancelled(Debtor debtor, int expectedCount, double expectedRate, double sumOfAllReceivables, double sumOfCancelled, double expectedCancelledSumRate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedCount, result.Cancelled.Count);
            Assert.Equal(expectedRate, result.Cancelled.CountRate);
            Assert.Equal(sumOfAllReceivables, result.All.Value);
            Assert.Equal(sumOfCancelled, result.Cancelled.Value);
            Assert.Equal(expectedCancelledSumRate, result.Cancelled.ValueRate);

        }
    }
}
