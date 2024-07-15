using FurnitureStore.APIs.Dtos;
using FurnitureStore.Infrastructure.Models;

namespace FurnitureStore.APIs.Extensions;

public static class CategoriesExtensions
{
    public static Category ToDto(this CategoryDbModel model)
    {
        return new Category
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Description = model.Description,
            Name = model.Name,
            Products = model.Products?.Select(x => x.Id).ToList(),
        };
    }

    public static CategoryDbModel ToModel(
        this CategoryUpdateInput updateDto,
        CategoryWhereUniqueInput uniqueId
    )
    {
        var category = new CategoryDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            category.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            category.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return category;
    }
}
