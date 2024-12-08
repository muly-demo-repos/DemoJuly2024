using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class SessionsController : SessionsControllerBase
{
    public SessionsController(ISessionsService service)
        : base(service) { }
}
