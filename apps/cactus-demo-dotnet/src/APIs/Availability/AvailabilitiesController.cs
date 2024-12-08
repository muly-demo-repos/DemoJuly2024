using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class AvailabilitiesController : AvailabilitiesControllerBase
{
    public AvailabilitiesController(IAvailabilitiesService service)
        : base(service) { }
}
