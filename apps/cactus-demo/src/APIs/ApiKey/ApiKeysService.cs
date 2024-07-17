using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class ApiKeysService : ApiKeysServiceBase
{
    public ApiKeysService(CactusDemoDbContext context)
        : base(context) { }
}
