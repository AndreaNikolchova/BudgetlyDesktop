namespace BudgetlyDesktop.Services.Transaction.Contracts
{
    using BugetlyDesktop.ViewModels.Transaction;

    public interface ITransactionService
    {
        Task<IEnumerable<TransactionViewModel>> GetAllTransactionsAsync();
        Task<IEnumerable<TransactionTypeViewModel>> GetByTypeAsync(string type);
        Task<decimal> GetBalanceAsync();
        Task<decimal> GetIncomeAsync();
        Task<decimal> GetExpenseAsync();
        Task<bool> AddTransactionAsync(AddTransactionViewModel transactionViewModel);
        Task<IEnumerable<TransactionViewModel>> GetFilteredTransactionsAsync(DateTime fromGetFilteredTransactionsAsync, DateTime to, string category, string type);
    }
}
