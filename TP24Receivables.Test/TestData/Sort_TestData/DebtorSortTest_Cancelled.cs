using TP24Receivables.Data.Models;

namespace TP24Receivables.Test.TestData.SortTestData
{
    internal class DebtorSortTest_Cancelled
    {
        public static IEnumerable<object[]> AllCancelled()
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
                                ClosedDate = DateTime.Now.AddDays(3),
                                Cancelled = true,
                                CurrencyCode = "USD"
                            },
                            new Receivable
                            {
                                DueDate = DateTime.Now.AddDays(2),
                                OpeningValue = 200.0,
                                PaidValue = 200.0,
                                ClosedDate = DateTime.Now.AddDays(1),
                                Cancelled = true,
                                CurrencyCode = "EUR"
                            },
                            new Receivable
                            {
                                DueDate = DateTime.Now.AddDays(7),
                                OpeningValue = 150.0,
                                PaidValue = 150.0,
                                ClosedDate = DateTime.Now.AddDays(4),
                                Cancelled = true,
                                CurrencyCode = "GBP"
                            },
                        }
                },
                3,
                1
            };
        }

        public static IEnumerable<object[]> HalfCancelled()
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
                                ClosedDate = DateTime.Now.AddDays(3),
                                Cancelled = true,
                                CurrencyCode = "USD"
                            },
                            new Receivable
                            {
                                DueDate = DateTime.Now.AddDays(2),
                                OpeningValue = 200.0,
                                PaidValue = 200.0,
                                ClosedDate = DateTime.Now.AddDays(1),
                                Cancelled = true,
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
                                DueDate = DateTime.Now.AddDays(7),
                                OpeningValue = 150.0,
                                PaidValue = 150.0,
                                ClosedDate = DateTime.Now.AddDays(4),
                                Cancelled = false,
                                CurrencyCode = "GBP"
                            },
                        }
                },
                2,
                0.5
            };
        }

        public static IEnumerable<object[]> NoneCancelled()
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
                                ClosedDate = DateTime.Now.AddDays(3),
                                Cancelled = false,
                                CurrencyCode = "USD"
                            },
                            new Receivable
                            {
                                DueDate = DateTime.Now.AddDays(2),
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
                                ClosedDate = DateTime.Now.AddDays(4),
                                CurrencyCode = "GBP"
                            },
                        }
                },
                0,
                0
            };
        }
    }
}