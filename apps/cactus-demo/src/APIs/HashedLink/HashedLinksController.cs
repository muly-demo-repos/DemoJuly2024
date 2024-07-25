using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class HashedLinksController : HashedLinksControllerBase
{
    public HashedLinksController(IHashedLinksService service)
        : base(service) { }
}
