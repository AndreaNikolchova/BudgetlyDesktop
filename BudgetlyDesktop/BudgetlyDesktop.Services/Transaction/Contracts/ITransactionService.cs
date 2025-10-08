namespace BudgetlyDesktop.Services.Transaction.Contracts
{
    using BugetlyDesktop.ViewModels.Transaction;
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionTypeViewModel>> GetByTypeAsync(string type);
        Task<decimal> GetBalanceAsync();
        Task<decimal> GetIncomeAsync();
        Task<decimal> GetExpenseAsync();

    }
}
