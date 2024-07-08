using QaService.APIs;

namespace QaService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITicketCategoriesService, TicketCategoriesService>();
        services.AddScoped<ITicketCriteriaService, TicketCriteriaService>();
    }
}
