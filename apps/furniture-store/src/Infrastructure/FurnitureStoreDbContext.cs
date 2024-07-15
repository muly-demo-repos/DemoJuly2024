using FurnitureStore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Infrastructure;

public class FurnitureStoreDbContext : DbContext
{
    public FurnitureStoreDbContext(DbContextOptions<FurnitureStoreDbContext> options)
        : base(options) { }

    public DbSet<CategoryDbModel> Categories { get; set; }

    public DbSet<ProductDbModel> Products { get; set; }

    public DbSet<SupplierDbModel> Suppliers { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }
}
