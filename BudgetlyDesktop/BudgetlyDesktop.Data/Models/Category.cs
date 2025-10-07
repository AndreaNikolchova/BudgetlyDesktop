
namespace BudgetlyDesktop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;

        public ICollection<Transaction> Transactions { get; set; }
    }
}
