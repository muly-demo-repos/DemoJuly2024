using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class AppModelsService : AppModelsServiceBase
{
    public AppModelsService(CactusDemoDbContext context)
        : base(context) { }
}
