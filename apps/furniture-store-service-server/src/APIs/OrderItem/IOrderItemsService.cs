using FurnitureStoreService.APIs.Common;
using FurnitureStoreService.APIs.Dtos;

namespace FurnitureStoreService.APIs;

public interface IOrderItemsService
{
    /// <summary>
    /// Create one OrderItem
    /// </summary>
    public Task<OrderItem> CreateOrderItem(OrderItemCreateInput orderitem);

    /// <summary>
    /// Delete one OrderItem
    /// </summary>
    public Task DeleteOrderItem(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many OrderItems
    /// </summary>
    public Task<List<OrderItem>> OrderItems(OrderItemFindManyArgs findManyArgs);

    /// <summary>
    /// Get one OrderItem
    /// </summary>
    public Task<OrderItem> OrderItem(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a order record for OrderItem
    /// </summary>
    public Task<Order> GetOrder(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a product record for OrderItem
    /// </summary>
    public Task<Product> GetProduct(OrderItemWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about OrderItem records
    /// </summary>
    public Task<MetadataDto> OrderItemsMeta(OrderItemFindManyArgs findManyArgs);

    /// <summary>
    /// Update one OrderItem
    /// </summary>
    public Task UpdateOrderItem(OrderItemWhereUniqueInput uniqueId, OrderItemUpdateInput updateDto);
}
