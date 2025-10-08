using BudgetlyDesktop.Data;
using BudgetlyDesktop.Services.Transaction;
using BudgetlyDesktop.Services.Transaction.Contracts;

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

           
            Application.Run(new MainForm(transactionService));
        }
    }
}
