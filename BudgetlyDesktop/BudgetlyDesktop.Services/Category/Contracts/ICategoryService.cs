namespace BudgetlyDesktop.Services.Category.Contracts
{

    public interface ICategoryService
    {
        Task<IEnumerable<string>> GetAllAsync();
    }
}
