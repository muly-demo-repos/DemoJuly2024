using QaService.APIs.Common;
using QaService.APIs.Dtos;

namespace QaService.APIs;

public interface ITicketCriteriaService
{
    /// <summary>
    /// Create one TicketCriteria
    /// </summary>
    public Task<TicketCriterion> CreateTicketCriterion(TicketCriterionCreateInput ticketcriterion);

    /// <summary>
    /// Delete one TicketCriteria
    /// </summary>
    public Task DeleteTicketCriterion(TicketCriterionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TicketCriteria
    /// </summary>
    public Task<List<TicketCriterion>> TicketCriteria(TicketCriterionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TicketCriteria
    /// </summary>
    public Task<TicketCriterion> TicketCriterion(TicketCriterionWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Ticket Category record for TicketCriteria
    /// </summary>
    public Task<TicketCategory> GetTicketCategory(TicketCriterionWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about TicketCriteria records
    /// </summary>
    public Task<MetadataDto> TicketCriteriaMeta(TicketCriterionFindManyArgs findManyArgs);

    /// <summary>
    /// Update one TicketCriteria
    /// </summary>
    public Task UpdateTicketCriterion(
        TicketCriterionWhereUniqueInput uniqueId,
        TicketCriterionUpdateInput updateDto
    );
}
