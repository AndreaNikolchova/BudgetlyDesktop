namespace BudgetlyDesktop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public decimal Amount {  get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
