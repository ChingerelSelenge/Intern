using InventorySystem.DTOs;
using InventorySystem.Models;

namespace InventorySystem.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<(bool Ok, string Err)> CreateAsync(CreateProductDto dto);
    Task<(bool Ok, string Err)> UpdateAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<IEnumerable<ProductResponseDto>> SearchAsync( string? searchTerm, int? categoryId, string sortBy = "name");
}