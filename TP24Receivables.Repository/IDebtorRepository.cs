using TP24Receivables.Data.Models;

namespace TP24Receivables.Repository;

public interface IDebtorRepository
{
    Task SaveDebtor(Debtor debtor);
}