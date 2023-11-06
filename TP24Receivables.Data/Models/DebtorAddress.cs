using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP24Receivables.Data.Models
{
    public class DebtorAddress : IEquatable<DebtorAddress>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }
        public string CountryCode { get; set; }

        public DebtorAddress()
        {
            
        }

        public DebtorAddress(Payload payload)
        {
            Address1 = payload.DebtorAddress1 ?? string.Empty;
            Address2 = payload.DebtorAddress2 ?? string.Empty;
            Town = payload.DebtorTown ?? string.Empty;
            State = payload.DebtorState ?? string.Empty;
            Zip = payload.DebtorZip ?? string.Empty;
            CountryCode = payload.DebtorCountryCode ?? string.Empty;
        }

        public bool Equals(DebtorAddress? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Address1 == other.Address1 && Address2 == other.Address2 && Town == other.Town && State == other.State && Zip == other.Zip && CountryCode == other.CountryCode;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DebtorAddress)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address1, Address2, Town, State, Zip, CountryCode);
        }
    }
}
