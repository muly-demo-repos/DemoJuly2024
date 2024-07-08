using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class CategoriesExtensions
{
    public static Category ToDto(this CategoryDbModel model)
    {
        return new Category
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Products = model.Products?.Select(x => x.Id).ToList(),
        };
    }

    public static CategoryDbModel ToModel(
        this CategoryUpdateInput updateDto,
        CategoryWhereUniqueInput uniqueId
    )
    {
        var category = new CategoryDbModel { Id = uniqueId.Id };

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
