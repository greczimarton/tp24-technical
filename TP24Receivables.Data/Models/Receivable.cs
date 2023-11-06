using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class Receivable
    {
        public string Reference { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime IssueDate { get; set; }
        public double OpeningValue { get; set; }
        public double PaidValue { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool? Cancelled { get; set; }

        public Receivable()
        {
            
        }

        public Receivable(Payload payload)
        {
            this.Reference = payload.Reference;
            this.CurrencyCode = payload.CurrencyCode;
            this.IssueDate = DateTime.Parse(payload.IssueDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
            this.OpeningValue = decimal.ToDouble(payload.OpeningValue);
            this.PaidValue = decimal.ToDouble(payload.PaidValue);
            this.DueDate = DateTime.Parse(payload.DueDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
            if (payload.ClosedDate != null)
            {
                this.ClosedDate = DateTime.Parse(payload.ClosedDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
            } 
            else
            {
                this.ClosedDate = null;
            }
            this.Cancelled = payload.Cancelled;
        }
    }
}
