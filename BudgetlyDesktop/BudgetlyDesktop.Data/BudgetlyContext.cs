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
            modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "Food", Type = "Expense" },
      new Category { Id = 2, Name = "Transport", Type = "Expense" },
      new Category { Id = 3, Name = "Entertainment", Type = "Expense" },
      new Category { Id = 4, Name = "Salary", Type = "Income" },
      new Category { Id = 5, Name = "Investments", Type = "Income" },
      new Category { Id = 6, Name = "Bills", Type = "Expense" }
  );




        }
    }
}


