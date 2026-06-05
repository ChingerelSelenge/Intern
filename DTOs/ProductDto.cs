using System.ComponentModel.DataAnnotations;

namespace InventorySystem.DTOs;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryName { get; set; } = "";
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
}

public class CreateProductDto
{
    [Required(ErrorMessage = "Нэр заавал байна")]
    [StringLength(200, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [Range(1, 999999999, ErrorMessage = "Үнэ 1-ээс их байна")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateProductDto
{
    [StringLength(200, MinimumLength = 2)]
    public string? Name { get; set; }

    [Range(1, 999999999)]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]

    public int? StockQuantity { get; set; }

    public int? CategoryId { get; set; }
}