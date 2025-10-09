namespace BudgetlyDesktop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class BudgetlyContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BudgetlyDesktop.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.Category)
                        .WithMany(c => c.Transactions)
                        .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.Type)
                        .WithMany(ty => ty.Transactions)
                        .HasForeignKey(t => t.TypeId);


            modelBuilder.Entity<Category>().HasData(
                        new Category { Id = 1, Name = "Food", },
                        new Category { Id = 2, Name = "Transport", },
                        new Category { Id = 3, Name = "Entertainment" },
                        new Category { Id = 4, Name = "Salary", },
                        new Category { Id = 5, Name = "Investments" },
                        new Category { Id = 6, Name = "Bills" });
            modelBuilder.Entity<Type>().HasData(
                        new Type { Id = 1, Name = "Income" },
                        new Type { Id = 2, Name = "Expense" });
        }
    }
}


