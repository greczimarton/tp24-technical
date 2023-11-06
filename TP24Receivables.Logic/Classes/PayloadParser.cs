using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Logic.Classes
{
    public static class PayloadParser
    {
        public static List<Debtor> Parse(List<Payload> payloads)
        {
            var groupedPayloads = payloads.GroupBy(payload => payload.DebtorReference);

            var result = new List<Debtor>();

            foreach (var group in groupedPayloads)
            {
                var debtor = new Debtor()
                {
                    Id = Guid.NewGuid(),
                    Reference = group.Key,
                };

                foreach (var payload in group)
                {
                    UpdateDebtorFieldIfEmpty(debtor, "RegistrationNumber", payload.DebtorRegistrationNumber);
                    UpdateDebtorFieldIfEmpty(debtor, "Name", payload.DebtorName);

                    var debtorAddressFromReceivable = new DebtorAddress(payload);
                    var receivable = new Receivable(payload);

                    debtor.DebtorAddresses.Add(debtorAddressFromReceivable);
                    debtor.Receivables.Add(receivable);
                }

                result.Add(debtor);
            }

            return result;
        }

        private static void UpdateDebtorFieldIfEmpty(Debtor debtor, string fieldName, string payloadValue)
        {
            // Check if the specified field in the debtor is empty or null
            var debtorFieldValue = debtor.GetType().GetProperty(fieldName)?.GetValue(debtor) as string;

            if (string.IsNullOrWhiteSpace(debtorFieldValue) && !string.IsNullOrWhiteSpace(payloadValue))
            {
                debtor.GetType().GetProperty(fieldName)?.SetValue(debtor, payloadValue);
            }
        }
    }
}
