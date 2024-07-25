using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class ImpersonationsController : ImpersonationsControllerBase
{
    public ImpersonationsController(IImpersonationsService service)
        : base(service) { }
}
