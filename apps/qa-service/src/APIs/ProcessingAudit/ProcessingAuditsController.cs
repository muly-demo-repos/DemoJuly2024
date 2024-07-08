using Microsoft.AspNetCore.Mvc;

namespace QaService.APIs;

[ApiController()]
public class ProcessingAuditsController : ProcessingAuditsControllerBase
{
    public ProcessingAuditsController(IProcessingAuditsService service)
        : base(service) { }
}
