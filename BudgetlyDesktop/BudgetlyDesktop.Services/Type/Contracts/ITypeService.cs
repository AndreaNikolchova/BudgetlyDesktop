
namespace BudgetlyDesktop.Services.Type.Contracts
{
    public interface ITypeService
    {
        Task<IEnumerable<string>> GetTypesAsync();
    }
}
