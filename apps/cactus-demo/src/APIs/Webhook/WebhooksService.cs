using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class WebhooksService : WebhooksServiceBase
{
    public WebhooksService(CactusDemoDbContext context)
        : base(context) { }
}
