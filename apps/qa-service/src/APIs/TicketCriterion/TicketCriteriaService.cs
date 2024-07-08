using QaService.Infrastructure;

namespace QaService.APIs;

public class TicketCriteriaService : TicketCriteriaServiceBase
{
    public TicketCriteriaService(QaServiceDbContext context)
        : base(context) { }
}
