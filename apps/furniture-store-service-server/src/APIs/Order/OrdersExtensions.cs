using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class OrdersExtensions
{
    public static Order ToDto(this OrderDbModel model)
    {
        return new Order
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            OrderItems = model.OrderItems?.Select(x => x.Id).ToList(),
            OrderDate = model.OrderDate,
            TotalAmount = model.TotalAmount,
            Customer = model.CustomerId,
            AgentName = model.AgentName,
            OrderPriority = model.OrderPriority,
        };
    }

    public static OrderDbModel ToModel(
        this OrderUpdateInput updateDto,
        OrderWhereUniqueInput uniqueId
    )
    {
        var order = new OrderDbModel
        {
            Id = uniqueId.Id,
            OrderDate = updateDto.OrderDate,
            TotalAmount = updateDto.TotalAmount,
            AgentName = updateDto.AgentName,
            OrderPriority = updateDto.OrderPriority
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return order;
    }
}
