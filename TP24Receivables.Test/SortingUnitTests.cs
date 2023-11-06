using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic;
using TP24Receivables.Logic.Models;
using TP24Receivables.Test.TestData;
using TP24Receivables.Test.TestData.SortTestData;

namespace TP24Receivables.Test
{
    public class SortingUnitTests
    {
        private readonly IStatisticsConfig mockStatisticsConfig;

        public SortingUnitTests()
        {
            mockStatisticsConfig = TestSetup.CreateMockStatisticsConfig();
        }

        [Theory]
        [MemberData(nameof(DebtorSortTest_Cancelled.AllCancelled), MemberType = typeof(DebtorSortTest_Cancelled))]
        [MemberData(nameof(DebtorSortTest_Cancelled.HalfCancelled), MemberType = typeof(DebtorSortTest_Cancelled))]
        [MemberData(nameof(DebtorSortTest_Cancelled.NoneCancelled), MemberType = typeof(DebtorSortTest_Cancelled))]
        public void SortsReceivables_Cancelled(Debtor debtor, int expectedCount, double expectedRate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedCount, result.Cancelled.Count);
            Assert.Equal(expectedRate, result.Cancelled.CountRate);
        }

        [Theory]
        [MemberData(nameof(DebtorSortTest_Open.AllOpen), MemberType = typeof(DebtorSortTest_Open))]
        [MemberData(nameof(DebtorSortTest_Open.HalfOpen), MemberType = typeof(DebtorSortTest_Open))]
        [MemberData(nameof(DebtorSortTest_Open.NoneOpen), MemberType = typeof(DebtorSortTest_Open))]
        public void SortsReceivables_Open(Debtor debtor, int expectedCount, double expectedRate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedCount, result.Open.Count);
            Assert.Equal(expectedRate, result.Open.CountRate);
        }


        [Theory]
        [MemberData(nameof(DebtorSortTest_Late.AllLate), MemberType = typeof(DebtorSortTest_Late))]
        [MemberData(nameof(DebtorSortTest_Late.HalfLate), MemberType = typeof(DebtorSortTest_Late))]
        [MemberData(nameof(DebtorSortTest_Late.NoneLate), MemberType = typeof(DebtorSortTest_Late))]
        public void SortsReceivables_Late(Debtor debtor, int expectedCount, double expectedRate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedCount, result.Late.Count);
            Assert.Equal(expectedRate, result.Late.CountRate);
        }

        [Theory]
        [MemberData(nameof(DebtorSortTest_Closed.AllClosed), MemberType = typeof(DebtorSortTest_Closed))]
        [MemberData(nameof(DebtorSortTest_Closed.HalfClosed), MemberType = typeof(DebtorSortTest_Closed))]
        [MemberData(nameof(DebtorSortTest_Closed.NoneClosed), MemberType = typeof(DebtorSortTest_Closed))]
        public void SortsReceivables_Closed(Debtor debtor, int expectedCount, double expectedRate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedCount, result.Closed.Count);
            Assert.Equal(expectedRate, result.Closed.CountRate);
        }

        [Theory]
        [MemberData(nameof(DebtorSortTest_ClosedLate.AllClosedLate), MemberType = typeof(DebtorSortTest_ClosedLate))]
        [MemberData(nameof(DebtorSortTest_ClosedLate.HalfClosedLate), MemberType = typeof(DebtorSortTest_ClosedLate))]
        [MemberData(nameof(DebtorSortTest_ClosedLate.NoneClosedLate), MemberType = typeof(DebtorSortTest_ClosedLate))]
        public void SortsReceivables_ClosedLate(Debtor debtor, int expectedClosedLate)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedClosedLate, result.ClosedLate);
        }

        [Theory]
        [MemberData(nameof(DebtorSortTest_DueIn7Days.AllDue), MemberType = typeof(DebtorSortTest_DueIn7Days))]
        [MemberData(nameof(DebtorSortTest_DueIn7Days.HalfDue), MemberType = typeof(DebtorSortTest_DueIn7Days))]
        [MemberData(nameof(DebtorSortTest_DueIn7Days.NoneDue), MemberType = typeof(DebtorSortTest_DueIn7Days))]
        public void SortsReceivables_DueIn7Days(Debtor debtor, int expectedDueIn7Days)
        {
            var logic = new ReceivablesLogic(new List<Debtor> { debtor }, mockStatisticsConfig);

            // Act
            var result = logic.GetStatisticsForDebtor(debtor);

            // Assert
            Assert.Equal(expectedDueIn7Days, result.DueIn7Days);
        }
    }
}
