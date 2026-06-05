using InventorySystem.Data;
using InventorySystem.DTOs;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _ctx;
    public ProductRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        => await _ctx.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Where(p => p.IsActive)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name,
                IsActive = p.IsActive
            })
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _ctx.Products.FindAsync(id);

    public async Task<Product> CreateAsync(CreateProductDto dto)
    {
        var p = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            StockQuantity = dto.StockQuantity,
            CategoryId = dto.CategoryId
        };

        _ctx.Products.Add(p);
        await _ctx.SaveChangesAsync();
        return p;
    }

    public async Task<Product?> UpdateAsync(int id, UpdateProductDto dto)
    {
        var p = await _ctx.Products.FindAsync(id);
        if (p == null) return null;

        if (dto.Name != null) p.Name = dto.Name;
        if (dto.Price.HasValue) p.Price = dto.Price.Value;
        if (dto.StockQuantity.HasValue) p.StockQuantity = dto.StockQuantity.Value;
        if (dto.CategoryId.HasValue) p.CategoryId = dto.CategoryId.Value;

        await _ctx.SaveChangesAsync();
        return p;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var p = await _ctx.Products.FindAsync(id);
        if (p == null) return false;

        p.IsActive = false;
        await _ctx.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
        => await _ctx.Categories.ToListAsync();
}