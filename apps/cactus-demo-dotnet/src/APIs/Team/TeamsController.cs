using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class TeamsController : TeamsControllerBase
{
    public TeamsController(ITeamsService service)
        : base(service) { }
}
