namespace BudgetlyDesktop.Services.Category
{
   
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
        public async Task<IEnumerable<string>> GetAllAsync()
        {
            List<string> categories = await this.dbContext.Categories.Select(c=>c.Name)
            .AsNoTracking()
            .ToListAsync();

            return categories;
        }
    }
}
