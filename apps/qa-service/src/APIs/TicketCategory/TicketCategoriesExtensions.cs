using QaService.APIs.Dtos;
using QaService.Infrastructure.Models;

namespace QaService.APIs.Extensions;

public static class TicketCategoriesExtensions
{
    public static TicketCategory ToDto(this TicketCategoryDbModel model)
    {
        return new TicketCategory
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            CategoryName = model.CategoryName,
            TicketCriteria = model.TicketCriteria?.Select(x => x.Id).ToList(),
        };
    }

    public static TicketCategoryDbModel ToModel(
        this TicketCategoryUpdateInput updateDto,
        TicketCategoryWhereUniqueInput uniqueId
    )
    {
        var ticketCategory = new TicketCategoryDbModel
        {
            Id = uniqueId.Id,
            CategoryName = updateDto.CategoryName
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            ticketCategory.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            ticketCategory.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return ticketCategory;
    }
}
