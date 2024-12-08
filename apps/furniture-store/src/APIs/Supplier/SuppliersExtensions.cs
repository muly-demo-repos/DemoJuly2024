using FurnitureStore.APIs.Dtos;
using FurnitureStore.Infrastructure.Models;

namespace FurnitureStore.APIs.Extensions;

public static class SuppliersExtensions
{
    public static Supplier ToDto(this SupplierDbModel model)
    {
        return new Supplier
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Name = model.Name,
            ContactPerson = model.ContactPerson,
            Phone = model.Phone,
            Email = model.Email,
            Products = model.Products?.Select(x => x.Id).ToList(),
        };
    }

    public static SupplierDbModel ToModel(
        this SupplierUpdateInput updateDto,
        SupplierWhereUniqueInput uniqueId
    )
    {
        var supplier = new SupplierDbModel
        {
            Id = uniqueId.Id,
            Name = updateDto.Name,
            ContactPerson = updateDto.ContactPerson,
            Phone = updateDto.Phone,
            Email = updateDto.Email
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            supplier.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            supplier.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return supplier;
    }
}
