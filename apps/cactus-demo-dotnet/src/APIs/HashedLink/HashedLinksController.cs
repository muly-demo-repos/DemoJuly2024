using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class HashedLinksController : HashedLinksControllerBase
{
    public HashedLinksController(IHashedLinksService service)
        : base(service) { }
}
