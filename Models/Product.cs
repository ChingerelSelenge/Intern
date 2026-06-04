using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Бараа нэр заавал байна")]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 999999999)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}