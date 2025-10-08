namespace BudgetlyDesktop.Services.Transaction
{
    using BudgetlyDesktop.Data;
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
                .Where(t => t.Type.ToLower() == type.ToLower())
                .Select(t => new TransactionTypeViewModel
                {
                    Type = t.Type,
                    Amount = t.Amount
                })
                .AsNoTracking()
                .ToListAsync();
            return transactions;
        }
    }
}
