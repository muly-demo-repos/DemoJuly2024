using FurnitureStore.APIs;

namespace FurnitureStore;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<ISuppliersService, SuppliersService>();
    }
}
