using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (dbCreator == null)
                {
                    Debug.WriteLine("Could not get RelationalDatabaseCreator");
                    return;
                }

                if (!dbCreator.CanConnect())
                {
                    Debug.WriteLine("Could not connect to database");
                    return;
                }

                if (dbCreator.HasTables())
                {
                    Debug.WriteLine("Database already has tables. Returning...");
                    return;
                }
            
                dbCreator.CreateTables();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occured during dbContext creation: {ex.Message}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDebtors(modelBuilder);
            CreateDebtorAddresses(modelBuilder);
            CreateReceivables(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private void CreateDebtors(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Debtor>();
            entity.ToTable("debtors");
        }
        
        private void CreateDebtorAddresses(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DebtorAddress>();
            entity.ToTable("debtorAddresses");
        }
        
        private void CreateReceivables(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Receivable>();
            entity.ToTable("receivables");
        }
    }
}
