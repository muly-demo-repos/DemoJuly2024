using QaService.Infrastructure;

namespace QaService.APIs;

public class ProcessingAuditsService : ProcessingAuditsServiceBase
{
    public ProcessingAuditsService(QaServiceDbContext context)
        : base(context) { }
}
