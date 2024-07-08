using QaService.APIs.Common;
using QaService.APIs.Dtos;

namespace QaService.APIs;

public interface IProcessingAuditsService
{
    public Task<double> CalculateSomething(string data);

    /// <summary>
    /// Create one ProcessingAudit
    /// </summary>
    public Task<ProcessingAudit> CreateProcessingAudit(ProcessingAuditCreateInput processingaudit);

    /// <summary>
    /// Delete one ProcessingAudit
    /// </summary>
    public Task DeleteProcessingAudit(ProcessingAuditWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ProcessingAudits
    /// </summary>
    public Task<List<ProcessingAudit>> ProcessingAudits(ProcessingAuditFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ProcessingAudit
    /// </summary>
    public Task<ProcessingAudit> ProcessingAudit(ProcessingAuditWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about ProcessingAudit records
    /// </summary>
    public Task<MetadataDto> ProcessingAuditsMeta(ProcessingAuditFindManyArgs findManyArgs);

    /// <summary>
    /// Update one ProcessingAudit
    /// </summary>
    public Task UpdateProcessingAudit(
        ProcessingAuditWhereUniqueInput uniqueId,
        ProcessingAuditUpdateInput updateDto
    );
}
