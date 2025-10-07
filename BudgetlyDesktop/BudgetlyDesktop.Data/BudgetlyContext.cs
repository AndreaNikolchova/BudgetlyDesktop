namespace BudgetlyDesktop.Data
{
using Microsoft.EntityFrameworkCore;
using Models;
    public class BudgetlyContext : DbContext
    {
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite("Data Source=BudgetlyDesktop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.Category)
                        .WithMany(c => c.Transactions)
                        .HasForeignKey(t => t.CategoryId);
        }
    }
}
