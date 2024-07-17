using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class MembershipsController : MembershipsControllerBase
{
    public MembershipsController(IMembershipsService service)
        : base(service) { }
}
