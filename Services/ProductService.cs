using InventorySystem.DTOs;
using InventorySystem.Models;
using InventorySystem.Repositories;

namespace InventorySystem.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
        => _repo = repo;

    public Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        => _repo.GetAllAsync();

    public Task<Product?> GetByIdAsync(int id)
        => _repo.GetByIdAsync(id);

    public async Task<(bool, string)> CreateAsync(CreateProductDto dto)
    {
        if (dto.Price < 1)
            return (false, "Үнэ 1-ээс их байх ёстой");

        await _repo.CreateAsync(dto);
        return (true, "");
    }

    public async Task<(bool, string)> UpdateAsync(int id, UpdateProductDto dto)
    {
        var result = await _repo.UpdateAsync(id, dto);
        return result == null
            ? (false, "Бараа олдсонгүй")
            : (true, "");
    }

    public Task<bool> DeleteAsync(int id)
        => _repo.DeleteAsync(id);

    public Task<IEnumerable<Category>> GetCategoriesAsync()
        => _repo.GetCategoriesAsync();
}