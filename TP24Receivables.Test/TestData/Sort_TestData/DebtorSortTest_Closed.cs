using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Test.TestData.SortTestData
{
    internal static class DebtorSortTest_Closed
    {

        public static IEnumerable<object[]> AllClosed()
        {
            yield return new object[]
            {
                new Debtor
                {
                    Reference = "D1",
                    Name = "Debtor 1",
                    Receivables = new List<Receivable>
                    {
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(5),
                            OpeningValue = 100.0,
                            ClosedDate = DateTime.Now.AddDays(-1),
                            PaidValue = 100.0,
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(2),
                            OpeningValue = 200.0,
                            ClosedDate = DateTime.Now.AddDays(-7),
                            PaidValue = 200.0,
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now,
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                3,
                1
            };
        }

        public static IEnumerable<object[]> NoneClosed()
        {
            yield return new object[]
            {
                new Debtor
                {
                    Reference = "D1",
                    Name = "Debtor 1",
                    Receivables = new List<Receivable>
                    {
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(12),
                            OpeningValue = 100.0,
                            PaidValue = 100.0,
                            ClosedDate = DateTime.Now.AddDays(3),
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(9),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(14),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now.AddDays(5),
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                0,
                0
            };
        }

        public static IEnumerable<object[]> HalfClosed()
        {
            yield return new object[]
            {
                new Debtor
                {
                    Reference = "D1",
                    Name = "Debtor 1",
                    Receivables = new List<Receivable>
                    {
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(12),
                            OpeningValue = 100.0,
                            ClosedDate = DateTime.Now.AddDays(-1),
                            PaidValue = 100.0,
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(9),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
                            ClosedDate = DateTime.Now.AddDays(-5),
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now.AddDays(4),
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(5),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                2,
                0.5
            };
        }

    }
}
