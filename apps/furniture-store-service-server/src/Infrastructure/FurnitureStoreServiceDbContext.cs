using FurnitureStoreService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStoreService.Infrastructure;

public class FurnitureStoreServiceDbContext : DbContext
{
    public FurnitureStoreServiceDbContext(DbContextOptions<FurnitureStoreServiceDbContext> options)
        : base(options) { }

    public DbSet<ProductDbModel> Products { get; set; }

    public DbSet<CategoryDbModel> Categories { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<OrderItemDbModel> OrderItems { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }
}
