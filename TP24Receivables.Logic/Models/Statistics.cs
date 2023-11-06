using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Logic.Models
{
    public class Statistics
    {
        public string DebtorReference {  get; set; }
        public string DebtorName { get; set; }
        public string CurrencyCode { get; set; }
        public Metric All { get; set; }
        public Metric Cancelled {  get; set; }
        public Metric Open { get; set; }
        public Metric Late { get; set; }

        public int DueIn7Days { get; set; }
        public Metric Closed { get; set; }
        public int ClosedLate { get; set; }
    }
}
