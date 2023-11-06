using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class Debtor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Reference { get; set; }
        public string? RegistrationNumber { get; set; } = null;
        public List<DebtorAddress> DebtorAddresses { get; set;} = new List<DebtorAddress>();
        public List<Receivable> Receivables { get; set; } = new List<Receivable>();
    }
}
