using QaService.APIs.Common;
using QaService.APIs.Dtos;

namespace QaService.APIs;

public interface ITicketCategoriesService
{
    /// <summary>
    /// Create one TicketCategory
    /// </summary>
    public Task<TicketCategory> CreateTicketCategory(TicketCategoryCreateInput ticketcategory);

    /// <summary>
    /// Delete one TicketCategory
    /// </summary>
    public Task DeleteTicketCategory(TicketCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TicketCategories
    /// </summary>
    public Task<List<TicketCategory>> TicketCategories(TicketCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TicketCategory
    /// </summary>
    public Task<TicketCategory> TicketCategory(TicketCategoryWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about TicketCategory records
    /// </summary>
    public Task<MetadataDto> TicketCategoriesMeta(TicketCategoryFindManyArgs findManyArgs);

    /// <summary>
    /// Connect multiple TicketCriteria records to TicketCategory
    /// </summary>
    public Task ConnectTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    );

    /// <summary>
    /// Disconnect multiple TicketCriteria records from TicketCategory
    /// </summary>
    public Task DisconnectTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    );

    /// <summary>
    /// Find multiple TicketCriteria records for TicketCategory
    /// </summary>
    public Task<List<TicketCriterion>> FindTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionFindManyArgs TicketCriterionFindManyArgs
    );

    /// <summary>
    /// Update multiple TicketCriteria records for TicketCategory
    /// </summary>
    public Task UpdateTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    );

    /// <summary>
    /// Update one TicketCategory
    /// </summary>
    public Task UpdateTicketCategory(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCategoryUpdateInput updateDto
    );
}
