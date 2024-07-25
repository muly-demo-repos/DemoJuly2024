using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class AvailabilitiesController : AvailabilitiesControllerBase
{
    public AvailabilitiesController(IAvailabilitiesService service)
        : base(service) { }
}
