namespace BudgetlyDesktop.Services.Category
{
    using BugetlyDesktop.ViewModels.Category;
    using Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BudgetlyDesktop.Data;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        public BudgetlyContext dbContext { get; set; }
        public CategoryService(BudgetlyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllASync()
        {
            List<CategoryViewModel> categories = await this.dbContext.Categories.Select(c=>new CategoryViewModel
            {
                Name = c.Name,
                Type = c.Type,
            }
            ).AsNoTracking()
            .ToListAsync();

            return categories;
        }
    }
}
