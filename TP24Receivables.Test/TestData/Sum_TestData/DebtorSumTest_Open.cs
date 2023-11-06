using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Test.SortTestData
{
    internal static class DebtorSumTest_Open
    {

        public static IEnumerable<object[]> AllOpen()
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
                            PaidValue = 100.0,
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(2),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
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
                    }
                },
                3,
                1
            };
        }

        public static IEnumerable<object[]> NoneOpen()
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
                            ClosedDate = DateTime.Now.AddDays(-3),
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(9),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
                            ClosedDate = DateTime.Now.AddDays(-4),
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(14),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now.AddDays(-5),
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                0,
                0
            };
        }

        public static IEnumerable<object[]> HalfOpen()
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
                            Cancelled = false,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(9),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
                            ClosedDate = DateTime.Now.AddDays(1),
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now.AddDays(-4),
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(5),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
                            ClosedDate = DateTime.Now.AddDays(-8),
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
