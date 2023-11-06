using Microsoft.EntityFrameworkCore;
using TP24Receivables.Data;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Repository;

public class ReceivablesRepository
{
    private readonly ReceivablesDbContext _dbContext;

    public ReceivablesRepository(ReceivablesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Receivable>> GetAllReceivables()
    {
        return await _dbContext.Receivables.ToListAsync();
    }
}