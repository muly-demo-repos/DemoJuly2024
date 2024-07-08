using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class ProductsExtensions
{
    public static Product ToDto(this ProductDbModel model)
    {
        return new Product
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Category = model.CategoryId,
            OrderItems = model.OrderItems?.Select(x => x.Id).ToList(),
        };
    }

    public static ProductDbModel ToModel(
        this ProductUpdateInput updateDto,
        ProductWhereUniqueInput uniqueId
    )
    {
        var product = new ProductDbModel
        {
            Id = uniqueId.Id,
            Name = updateDto.Name,
            Description = updateDto.Description,
            Price = updateDto.Price
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            product.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            product.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return product;
    }
}
