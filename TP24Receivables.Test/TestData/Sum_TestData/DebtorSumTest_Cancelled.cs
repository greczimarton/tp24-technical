using TP24Receivables.Data.Models;

namespace TP24Receivables.Test.SortTestData
{
    internal class DebtorSumTest_Cancelled
    {
        public static IEnumerable<object[]> AllCancelled()
        {
            yield return new object[]
            {
                new Debtor
                {
                    Reference = "D1",
                    Name = "Debtor 1",
                    Receivables = new List<Receivable> {
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
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 100.0,
                            PaidValue = 100.0,
                            ClosedDate = DateTime.Now.AddDays(4),
                            Cancelled = true,
                            CurrencyCode = "CHF"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 500.0,
                            PaidValue = 500.0,
                            ClosedDate = DateTime.Now.AddDays(4),
                            Cancelled = true,
                            CurrencyCode = "USD"
                        },
                    }
                },
                5,
                1,
                1034.5,
                1034.5,
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
                    Receivables = new List<Receivable> {
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(5),
                            OpeningValue = 199.0,
                            PaidValue = 199.0,
                            ClosedDate = DateTime.Now.AddDays(3),
                            Cancelled = true,
                            CurrencyCode = "USD"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(2),
                            OpeningValue = 250.0,
                            PaidValue = 250.0,
                            ClosedDate = DateTime.Now.AddDays(1),
                            Cancelled = true,
                            CurrencyCode = "EUR"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 99.0,
                            PaidValue = 99.0,
                            ClosedDate = DateTime.Now.AddDays(4),
                            Cancelled = false,
                            CurrencyCode = "GBP"
                        },
                        new Receivable
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            OpeningValue = 50.0,
                            PaidValue = 50.0,
                            ClosedDate = DateTime.Now.AddDays(4),
                            Cancelled = false,
                            CurrencyCode = "CHF"
                        },
                    }
                },
                2,
                0.5,
                600.92,
                435.07,
                0.72
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
                                Cancelled = false,
                                CurrencyCode = "GBP"
                            },
                        }
                },
                0,
                0,
                465.5,
                0,
                0
            };
        }
    }
}