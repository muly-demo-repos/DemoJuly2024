using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class ImpersonationsController : ImpersonationsControllerBase
{
    public ImpersonationsController(IImpersonationsService service)
        : base(service) { }
}
