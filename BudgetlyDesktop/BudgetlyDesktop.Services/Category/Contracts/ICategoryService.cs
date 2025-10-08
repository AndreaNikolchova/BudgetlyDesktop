namespace BudgetlyDesktop.Services.Category.Contracts
{
    using BugetlyDesktop.ViewModels.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllASync();
    }
}
