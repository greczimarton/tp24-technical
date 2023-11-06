using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Test.TestData.SortTestData
{
    internal static class DebtorSortTest_DueIn7Days
    {

        public static IEnumerable<object[]> AllDue()
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
                            DueDate = DateTime.Now.AddDays(3),
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
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                3,
            };
        }

        public static IEnumerable<object[]> NoneDue()
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
                            DueDate = DateTime.Now.AddDays(8),
                            OpeningValue = 200.0,
                            PaidValue = 200.0,
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(1),
                            OpeningValue = 150.0,
                            ClosedDate = DateTime.Now,
                            PaidValue = 150.0,
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                    }
                },
                0
            };
        }

        public static IEnumerable<object[]> HalfDue()
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
                            Cancelled = false,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 150.0,
                            PaidValue = 150.0,
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
                2
            };
        }

    }
}
