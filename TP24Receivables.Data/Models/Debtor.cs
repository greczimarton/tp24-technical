using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class Debtor
    {
        public Guid Id { get; set; }
        public string DebtorName { get; set; }
        public string DebtorReference { get; set; }
        public string? DebtorRegistrationNumber { get; set; } = null;
    }
}
