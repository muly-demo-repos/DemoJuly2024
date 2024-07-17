using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class MembershipsController : MembershipsControllerBase
{
    public MembershipsController(IMembershipsService service)
        : base(service) { }
}
