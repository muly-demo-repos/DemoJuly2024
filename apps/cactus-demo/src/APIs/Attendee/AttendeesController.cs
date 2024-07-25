using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class AttendeesController : AttendeesControllerBase
{
    public AttendeesController(IAttendeesService service)
        : base(service) { }
}
