namespace BugetlyDesktop.ViewModels.Transaction
{
    public class AddTransactionViewModel
    {
        public string Title { get; set; } = null!;
        
        public decimal Amount { get; set; }
        
        public DateTime Date { get; set; }
       
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
       
    }
}
