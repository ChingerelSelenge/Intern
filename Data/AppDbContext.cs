using Microsoft.EntityFrameworkCore;
using InventorySystem.Models;

namespace InventorySystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Хоол хүнс" },
                new Category { Id = 2, Name = "Электроник" },
                new Category { Id = 3, Name = "Бичиг хэрэг" }
            );

            mb.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Дэвтэр A4", Price = 2500, StockQuantity = 100, CategoryId = 3, IsActive = true },
                new Product { Id = 2, Name = "Хар бал", Price = 500, StockQuantity = 200, CategoryId = 3, IsActive = true },
                new Product { Id = 3, Name = "Тоног Samsung", Price = 199000, StockQuantity = 15, CategoryId = 2, IsActive = true },
                new Product { Id = 4, Name = "Цаасан хавтас", Price = 3500, StockQuantity = 50, CategoryId = 3, IsActive = true },
                new Product { Id = 5, Name = "Чихэвч JBL", Price = 89000, StockQuantity = 30, CategoryId = 2, IsActive = true },
                new Product { Id = 6, Name = "Цагаан будаа 5кг", Price = 18000, StockQuantity = 80, CategoryId = 1, IsActive = true },
                new Product { Id = 7, Name = "Гурил 2кг", Price = 6500, StockQuantity = 7, CategoryId = 1, IsActive = true },
                new Product { Id = 8, Name = "Нарийн бичгийн хэрэгсэл", Price = 12000, StockQuantity = 0, CategoryId = 3, IsActive = true },
                new Product { Id = 9, Name = "Keyboard Logitech", Price = 145000, StockQuantity = 12, CategoryId = 2, IsActive = true },
                new Product { Id = 10, Name = "Mouse wireless", Price = 65000, StockQuantity = 20, CategoryId = 2, IsActive = true },
                new Product { Id = 11, Name = "Тэмдэглэлийн дэвтэр", Price = 4500, StockQuantity = 60, CategoryId = 3, IsActive = true },
                new Product { Id = 12, Name = "Элсэн чихэр 1кг", Price = 4200, StockQuantity = 90, CategoryId = 1, IsActive = true }
            );
        }
    }
}