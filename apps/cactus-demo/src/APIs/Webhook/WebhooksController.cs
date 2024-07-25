using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class WebhooksController : WebhooksControllerBase
{
    public WebhooksController(IWebhooksService service)
        : base(service) { }
}
