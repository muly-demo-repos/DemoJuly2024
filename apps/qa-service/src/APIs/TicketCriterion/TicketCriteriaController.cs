using Microsoft.AspNetCore.Mvc;

namespace QaService.APIs;

[ApiController()]
public class TicketCriteriaController : TicketCriteriaControllerBase
{
    public TicketCriteriaController(ITicketCriteriaService service)
        : base(service) { }
}
