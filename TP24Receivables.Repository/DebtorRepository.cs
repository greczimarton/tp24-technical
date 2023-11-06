using Microsoft.EntityFrameworkCore;
using TP24Receivables.Data;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Repository;

public class DebtorRepository : IDebtorRepository
{
    private readonly ReceivablesDbContext _dbContext;

    public DebtorRepository(ReceivablesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveDebtor(Debtor debtor)
    {
        try
        {
            var existingDebtor = await _dbContext.Debtors.FirstOrDefaultAsync(d => d.Reference == debtor.Reference);
            
            if (existingDebtor != null)
            {
                existingDebtor.Name = debtor.Name;
                existingDebtor.RegistrationNumber = debtor.RegistrationNumber;
                existingDebtor.DebtorAddresses = debtor.DebtorAddresses;
                existingDebtor.Receivables = debtor.Receivables;
                await _dbContext.SaveChangesAsync();
            }

            await _dbContext.Debtors.AddAsync(debtor);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Exception occured: {ex.Message}");
        }
    }
}