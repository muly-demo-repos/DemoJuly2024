using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class AttendeesController : AttendeesControllerBase
{
    public AttendeesController(IAttendeesService service)
        : base(service) { }
}
