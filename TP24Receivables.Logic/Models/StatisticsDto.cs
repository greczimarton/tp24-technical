using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Logic.Models
{
    public class StatisticsDto
    {
        public string CurrencyCode { get; set; }
        public int NumberOfReceivables { get; set; }
        public int CancelledReceivables { get; set; }
        public double CancellationRate { get; set; }
        public int OpenReceivables { get; set; }
        public double OpenRate { get; set; }
        public double OpenReceivablesValue { get; set; }
        public int ClosedReceivables { get; set; }
        public double ClosedRate { get; set; }
        public double ClosedReceivablesValue { get; set; }
    }
}
