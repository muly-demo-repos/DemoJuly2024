using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class TeamsController : TeamsControllerBase
{
    public TeamsController(ITeamsService service)
        : base(service) { }
}
