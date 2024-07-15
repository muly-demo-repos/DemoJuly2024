using FurnitureStore.Infrastructure;

namespace FurnitureStore.APIs;

public class SuppliersService : SuppliersServiceBase
{
    public SuppliersService(FurnitureStoreDbContext context)
        : base(context) { }
}
