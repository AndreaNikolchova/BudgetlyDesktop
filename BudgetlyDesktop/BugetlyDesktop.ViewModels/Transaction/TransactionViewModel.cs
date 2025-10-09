
using System.ComponentModel.DataAnnotations;

namespace BugetlyDesktop.ViewModels.Transaction
{
    public class TransactionViewModel
    {
        public string Title { get; set; } = null!;
      
        public decimal Amount { get; set; }
      
        public DateTime Date { get; set; }
        public string Category { get; set; } = null!;
        public string Type { get; set; } = null!;

    }
}
