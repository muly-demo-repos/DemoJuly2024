using FurnitureStore.APIs.Dtos;
using FurnitureStore.Infrastructure.Models;

namespace FurnitureStore.APIs.Extensions;

public static class ProductsExtensions
{
    public static Product ToDto(this ProductDbModel model)
    {
        return new Product
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Description = model.Description,
            Name = model.Name,
            Price = model.Price,
            Category = model.CategoryId,
            Supplier = model.SupplierId,
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
            Description = updateDto.Description,
            Name = updateDto.Name,
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
