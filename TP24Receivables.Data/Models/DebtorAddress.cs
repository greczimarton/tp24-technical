using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class DebtorAddress
    {
        public Guid Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }
        public string CountryCode { get; set; }

    }
}
