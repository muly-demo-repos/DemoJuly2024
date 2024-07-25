using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class SessionsController : SessionsControllerBase
{
    public SessionsController(ISessionsService service)
        : base(service) { }
}
