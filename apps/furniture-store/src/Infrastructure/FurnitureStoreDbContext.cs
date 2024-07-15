using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.Infrastructure;

public class FurnitureStoreDbContext : DbContext
{
    public FurnitureStoreDbContext(DbContextOptions<FurnitureStoreDbContext> options)
        : base(options) { }
}
