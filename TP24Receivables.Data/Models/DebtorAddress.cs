using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class DebtorAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }
        public string CountryCode { get; set; }

        public DebtorAddress(Payload payload)
        {
            Address1 = payload.DebtorAddress1 ?? string.Empty;
            Address2 = payload.DebtorAddress2 ?? string.Empty;
            Town = payload.DebtorTown ?? string.Empty;
            State = payload.DebtorState ?? string.Empty;
            Zip = payload.DebtorZip ?? string.Empty;
            CountryCode = payload.DebtorCountryCode ?? string.Empty;
        }

    }
}
