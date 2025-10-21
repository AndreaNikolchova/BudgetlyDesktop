namespace BudgetlyDesktop.Services.Transaction
{
    using BudgetlyDesktop.Data;
    using BudgetlyDesktop.Data.Models;
    using BudgetlyDesktop.Services.Transaction.Contracts;
    using BugetlyDesktop.ViewModels.Transaction;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TransactionService : ITransactionService
    {
        public BudgetlyContext dbContext { get; set; }
        public TransactionService(BudgetlyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TransactionTypeViewModel>> GetByTypeAsync(string type)
        {
            List<TransactionTypeViewModel> transactions = await dbContext.Transactions
                .Where(t => t.Type.Name.ToLower() == type.ToLower())
                .Select(t => new TransactionTypeViewModel
                {
                    Type = t.Type.Name,
                    Amount = t.Amount
                })
                .AsNoTracking()
                .ToListAsync();
            return transactions;
        }

        public async Task<decimal> GetBalanceAsync()
        {
            var incomeTransactions = await GetByTypeAsync("income");
            var expenseTransactions = await GetByTypeAsync("expense");

            decimal income = incomeTransactions.Sum(t => t.Amount);
            decimal expense = expenseTransactions.Sum(t => t.Amount);

            return income - expense;
        }

        public async Task<decimal> GetIncomeAsync()
        {
            var incomeTransactions = await GetByTypeAsync("income");
            return incomeTransactions.Sum(t => t.Amount);
        }

        public async  Task<decimal> GetExpenseAsync()
        {
            var expenseTransactions = await GetByTypeAsync("expense");
            return expenseTransactions.Sum(t => t.Amount);

        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllTransactionsAsync()
        {
            List<TransactionViewModel> transactions = await this.dbContext.Transactions.Select(t => new TransactionViewModel
            {
                Title = t.Title,
                Amount = t.Amount,
                Date = t.Date,
                Category = t.Category.Name,
                Type = t.Type.Name
            })
            .AsNoTracking()
            .ToListAsync();
            return transactions;
        }

        public async Task<bool> AddTransactionAsync(AddTransactionViewModel model)
        {
            var transaction = new Transaction
            {
                Title = model.Title,
                Amount = model.Amount,
                Date = model.Date,
                CategoryId = model.CategoryId +1,
                TypeId = model.TypeId+1
            };

            await dbContext.Transactions.AddAsync(transaction);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
