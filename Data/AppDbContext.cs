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
                new Product
                {
                    Id = 1,
                    Name = "Дэвтэр A4",
                    Price = 2500,
                    StockQuantity = 100,
                    CategoryId = 3,
                    CreatedAt = new DateTime(2026, 1, 1),
                    IsActive = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Тоног",
                    Price = 199000,
                    StockQuantity = 15,
                    CategoryId = 2,
                    CreatedAt = new DateTime(2026, 1, 1),
                    IsActive = true
                }
            );
        }
    }
}