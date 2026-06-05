using InventorySystem.DTOs;
using InventorySystem.Models;

namespace InventorySystem.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(CreateProductDto dto);
    Task<Product?> UpdateAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesAsync();
}