using FurnitureStore.APIs;
using FurnitureStore.APIs.Common;
using FurnitureStore.APIs.Dtos;
using FurnitureStore.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStore.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProductsControllerBase : ControllerBase
{
    protected readonly IProductsService _service;

    public ProductsControllerBase(IProductsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Product
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Product>> CreateProduct(ProductCreateInput input)
    {
        var product = await _service.CreateProduct(input);

        return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute()] ProductWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteProduct(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Products
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Product>>> Products(
        [FromQuery()] ProductFindManyArgs filter
    )
    {
        return Ok(await _service.Products(filter));
    }

    /// <summary>
    /// Get one Product
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> Product([FromRoute()] ProductWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Product(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a category record for Product
    /// </summary>
    [HttpGet("{Id}/categories")]
    public async Task<ActionResult<List<Category>>> GetCategory(
        [FromRoute()] ProductWhereUniqueInput uniqueId
    )
    {
        var category = await _service.GetCategory(uniqueId);
        return Ok(category);
    }

    /// <summary>
    /// Get a supplier record for Product
    /// </summary>
    [HttpGet("{Id}/suppliers")]
    public async Task<ActionResult<List<Supplier>>> GetSupplier(
        [FromRoute()] ProductWhereUniqueInput uniqueId
    )
    {
        var supplier = await _service.GetSupplier(uniqueId);
        return Ok(supplier);
    }

    /// <summary>
    /// Meta data about Product records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ProductsMeta(
        [FromQuery()] ProductFindManyArgs filter
    )
    {
        return Ok(await _service.ProductsMeta(filter));
    }

    /// <summary>
    /// Update one Product
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateProduct(
        [FromRoute()] ProductWhereUniqueInput uniqueId,
        [FromQuery()] ProductUpdateInput productUpdateDto
    )
    {
        try
        {
            await _service.UpdateProduct(uniqueId, productUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
