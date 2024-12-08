using FurnitureStore.APIs.Common;
using FurnitureStore.APIs.Dtos;

namespace FurnitureStore.APIs;

public interface ISuppliersService
{
    /// <summary>
    /// Create one Supplier
    /// </summary>
    public Task<Supplier> CreateSupplier(SupplierCreateInput supplier);

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    public Task DeleteSupplier(SupplierWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    public Task<List<Supplier>> Suppliers(SupplierFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Supplier
    /// </summary>
    public Task<Supplier> Supplier(SupplierWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple Products records to Supplier
    /// </summary>
    public Task ConnectProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    );

    /// <summary>
    /// Disconnect multiple Products records from Supplier
    /// </summary>
    public Task DisconnectProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    );

    /// <summary>
    /// Find multiple Products records for Supplier
    /// </summary>
    public Task<List<Product>> FindProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductFindManyArgs ProductFindManyArgs
    );

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    public Task<MetadataDto> SuppliersMeta(SupplierFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Products records for Supplier
    /// </summary>
    public Task UpdateProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    );

    /// <summary>
    /// Update one Supplier
    /// </summary>
    public Task UpdateSupplier(SupplierWhereUniqueInput uniqueId, SupplierUpdateInput updateDto);
}
