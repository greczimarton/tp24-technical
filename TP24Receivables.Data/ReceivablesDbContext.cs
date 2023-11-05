using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Receivables.Data.Models;

namespace TP24Receivables.Data
{
    public class ReceivablesDbContext : DbContext
    {
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<DebtorAddress> DebtorAddresses { get; set; }
        public DbSet<Receivable> Receivables { get; set; }


        public ReceivablesDbContext(DbContextOptions<ReceivablesDbContext> options) : base(options)
        {
                
        }
    }
}
