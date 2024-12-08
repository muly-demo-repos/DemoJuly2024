using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class WebhooksService : WebhooksServiceBase
{
    public WebhooksService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
