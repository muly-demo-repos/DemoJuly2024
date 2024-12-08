using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class ApiKeysService : ApiKeysServiceBase
{
    public ApiKeysService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
