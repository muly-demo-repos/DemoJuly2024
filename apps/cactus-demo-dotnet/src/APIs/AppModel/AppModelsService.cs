using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class AppModelsService : AppModelsServiceBase
{
    public AppModelsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
