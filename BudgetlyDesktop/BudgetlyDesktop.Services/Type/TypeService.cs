namespace BudgetlyDesktop.Services.Type
{
    using BudgetlyDesktop.Data;
    using BudgetlyDesktop.Services.Type.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TypeService : ITypeService
    {
        public BudgetlyContext dbContext { get; set; }
        public TypeService(BudgetlyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async  Task<IEnumerable<string>> GetTypesAsync()
        {
            List<string> types = await this.dbContext.Types.Select(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
            return types;
        }
    }
}
