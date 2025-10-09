using BudgetlyDesktop.Data;
using BudgetlyDesktop.Services.Category;
using BudgetlyDesktop.Services.Category.Contracts;
using BudgetlyDesktop.Services.Transaction;
using BudgetlyDesktop.Services.Transaction.Contracts;
using BudgetlyDesktop.Services.Type;
using BudgetlyDesktop.Services.Type.Contracts;

namespace BudgetlyDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

         
            var dbContext = new BudgetlyContext();
            ITransactionService transactionService = new TransactionService(dbContext);
            ICategoryService categoryService = new CategoryService(dbContext);
            ITypeService typeService = new TypeService(dbContext);

           
            Application.Run(new MainForm(transactionService,categoryService,typeService));
        }
    }
}
