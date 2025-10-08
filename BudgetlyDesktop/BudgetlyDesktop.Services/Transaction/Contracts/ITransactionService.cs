namespace BudgetlyDesktop.Services.Transaction.Contracts
{
    using BugetlyDesktop.ViewModels.Transaction;
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionTypeViewModel>> GetByTypeAsync(string type);
    }
}
