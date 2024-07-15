using FurnitureStore.APIs;
using FurnitureStore.APIs.Common;
using FurnitureStore.APIs.Dtos;
using FurnitureStore.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SuppliersControllerBase : ControllerBase
{
    protected readonly ISuppliersService _service;

    public SuppliersControllerBase(ISuppliersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Supplier
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Supplier>> CreateSupplier(SupplierCreateInput input)
    {
        var supplier = await _service.CreateSupplier(input);

        return CreatedAtAction(nameof(Supplier), new { id = supplier.Id }, supplier);
    }

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSupplier([FromRoute()] SupplierWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSupplier(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Supplier>>> Suppliers(
        [FromQuery()] SupplierFindManyArgs filter
    )
    {
        return Ok(await _service.Suppliers(filter));
    }

    /// <summary>
    /// Get one Supplier
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Supplier>> Supplier(
        [FromRoute()] SupplierWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Supplier(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple Products records to Supplier
    /// </summary>
    [HttpPost("{Id}/products")]
    public async Task<ActionResult> ConnectProducts(
        [FromRoute()] SupplierWhereUniqueInput uniqueId,
        [FromQuery()] ProductWhereUniqueInput[] productsId
    )
    {
        try
        {
            await _service.ConnectProducts(uniqueId, productsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Products records from Supplier
    /// </summary>
    [HttpDelete("{Id}/products")]
    public async Task<ActionResult> DisconnectProducts(
        [FromRoute()] SupplierWhereUniqueInput uniqueId,
        [FromBody()] ProductWhereUniqueInput[] productsId
    )
    {
        try
        {
            await _service.DisconnectProducts(uniqueId, productsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Products records for Supplier
    /// </summary>
    [HttpGet("{Id}/products")]
    public async Task<ActionResult<List<Product>>> FindProducts(
        [FromRoute()] SupplierWhereUniqueInput uniqueId,
        [FromQuery()] ProductFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindProducts(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SuppliersMeta(
        [FromQuery()] SupplierFindManyArgs filter
    )
    {
        return Ok(await _service.SuppliersMeta(filter));
    }

    /// <summary>
    /// Update multiple Products records for Supplier
    /// </summary>
    [HttpPatch("{Id}/products")]
    public async Task<ActionResult> UpdateProducts(
        [FromRoute()] SupplierWhereUniqueInput uniqueId,
        [FromBody()] ProductWhereUniqueInput[] productsId
    )
    {
        try
        {
            await _service.UpdateProducts(uniqueId, productsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Supplier
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSupplier(
        [FromRoute()] SupplierWhereUniqueInput uniqueId,
        [FromQuery()] SupplierUpdateInput supplierUpdateDto
    )
    {
        try
        {
            await _service.UpdateSupplier(uniqueId, supplierUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
