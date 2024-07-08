using QaService.APIs.Dtos;
using QaService.Infrastructure.Models;

namespace QaService.APIs.Extensions;

public static class TicketCriteriaExtensions
{
    public static TicketCriterion ToDto(this TicketCriterionDbModel model)
    {
        return new TicketCriterion
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            TicketCategory = model.TicketCategoryId,
            Criteria = model.Criteria,
        };
    }

    public static TicketCriterionDbModel ToModel(
        this TicketCriterionUpdateInput updateDto,
        TicketCriterionWhereUniqueInput uniqueId
    )
    {
        var ticketCriterion = new TicketCriterionDbModel
        {
            Id = uniqueId.Id,
            Criteria = updateDto.Criteria
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            ticketCriterion.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            ticketCriterion.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return ticketCriterion;
    }
}
