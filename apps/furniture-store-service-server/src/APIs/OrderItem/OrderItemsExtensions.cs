using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class OrderItemsExtensions
{
    public static OrderItem ToDto(this OrderItemDbModel model)
    {
        return new OrderItem
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Price = model.Price,
            Quantity = model.Quantity,
            Order = model.OrderId,
            Product = model.ProductId,
        };
    }

    public static OrderItemDbModel ToModel(
        this OrderItemUpdateInput updateDto,
        OrderItemWhereUniqueInput uniqueId
    )
    {
        var orderItem = new OrderItemDbModel
        {
            Id = uniqueId.Id,
            Price = updateDto.Price,
            Quantity = updateDto.Quantity
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            orderItem.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            orderItem.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return orderItem;
    }
}
