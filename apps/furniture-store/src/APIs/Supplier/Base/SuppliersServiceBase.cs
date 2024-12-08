using FurnitureStore.APIs;
using FurnitureStore.APIs.Common;
using FurnitureStore.APIs.Dtos;
using FurnitureStore.APIs.Errors;
using FurnitureStore.APIs.Extensions;
using FurnitureStore.Infrastructure;
using FurnitureStore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.APIs;

public abstract class SuppliersServiceBase : ISuppliersService
{
    protected readonly FurnitureStoreDbContext _context;

    public SuppliersServiceBase(FurnitureStoreDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Supplier
    /// </summary>
    public async Task<Supplier> CreateSupplier(SupplierCreateInput createDto)
    {
        var supplier = new SupplierDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Name = createDto.Name,
            ContactPerson = createDto.ContactPerson,
            Phone = createDto.Phone,
            Email = createDto.Email
        };

        if (createDto.Id != null)
        {
            supplier.Id = createDto.Id;
        }
        if (createDto.Products != null)
        {
            supplier.Products = await _context
                .Products.Where(product =>
                    createDto.Products.Select(t => t.Id).Contains(product.Id)
                )
                .ToListAsync();
        }

        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SupplierDbModel>(supplier.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    public async Task DeleteSupplier(SupplierWhereUniqueInput uniqueId)
    {
        var supplier = await _context.Suppliers.FindAsync(uniqueId.Id);
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    public async Task<List<Supplier>> Suppliers(SupplierFindManyArgs findManyArgs)
    {
        var suppliers = await _context
            .Suppliers.Include(x => x.Products)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return suppliers.ConvertAll(supplier => supplier.ToDto());
    }

    /// <summary>
    /// Get one Supplier
    /// </summary>
    public async Task<Supplier> Supplier(SupplierWhereUniqueInput uniqueId)
    {
        var suppliers = await this.Suppliers(
            new SupplierFindManyArgs { Where = new SupplierWhereInput { Id = uniqueId.Id } }
        );
        var supplier = suppliers.FirstOrDefault();
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        return supplier;
    }

    /// <summary>
    /// Connect multiple Products records to Supplier
    /// </summary>
    public async Task ConnectProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    )
    {
        var supplier = await _context
            .Suppliers.Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        var products = await _context
            .Products.Where(t => productsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (products.Count == 0)
        {
            throw new NotFoundException();
        }

        var productsToConnect = products.Except(supplier.Products);

        foreach (var product in productsToConnect)
        {
            supplier.Products.Add(product);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Products records from Supplier
    /// </summary>
    public async Task DisconnectProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    )
    {
        var supplier = await _context
            .Suppliers.Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        var products = await _context
            .Products.Where(t => productsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var product in products)
        {
            supplier.Products?.Remove(product);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Products records for Supplier
    /// </summary>
    public async Task<List<Product>> FindProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductFindManyArgs supplierFindManyArgs
    )
    {
        var products = await _context
            .Products.Where(m => m.SupplierId == uniqueId.Id)
            .ApplyWhere(supplierFindManyArgs.Where)
            .ApplySkip(supplierFindManyArgs.Skip)
            .ApplyTake(supplierFindManyArgs.Take)
            .ApplyOrderBy(supplierFindManyArgs.SortBy)
            .ToListAsync();

        return products.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    public async Task<MetadataDto> SuppliersMeta(SupplierFindManyArgs findManyArgs)
    {
        var count = await _context.Suppliers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Products records for Supplier
    /// </summary>
    public async Task UpdateProducts(
        SupplierWhereUniqueInput uniqueId,
        ProductWhereUniqueInput[] productsId
    )
    {
        var supplier = await _context
            .Suppliers.Include(t => t.Products)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        var products = await _context
            .Products.Where(a => productsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (products.Count == 0)
        {
            throw new NotFoundException();
        }

        supplier.Products = products;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Supplier
    /// </summary>
    public async Task UpdateSupplier(
        SupplierWhereUniqueInput uniqueId,
        SupplierUpdateInput updateDto
    )
    {
        var supplier = updateDto.ToModel(uniqueId);

        if (updateDto.Products != null)
        {
            supplier.Products = await _context
                .Products.Where(product => updateDto.Products.Select(t => t).Contains(product.Id))
                .ToListAsync();
        }

        _context.Entry(supplier).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Suppliers.Any(e => e.Id == supplier.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
