using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class WebhooksController : WebhooksControllerBase
{
    public WebhooksController(IWebhooksService service)
        : base(service) { }
}
