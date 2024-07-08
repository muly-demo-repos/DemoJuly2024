using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;

namespace QaService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TicketCategoriesControllerBase : ControllerBase
{
    protected readonly ITicketCategoriesService _service;

    public TicketCategoriesControllerBase(ITicketCategoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TicketCategory
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<TicketCategory>> CreateTicketCategory(
        TicketCategoryCreateInput input
    )
    {
        var ticketCategory = await _service.CreateTicketCategory(input);

        return CreatedAtAction(
            nameof(TicketCategory),
            new { id = ticketCategory.Id },
            ticketCategory
        );
    }

    /// <summary>
    /// Delete one TicketCategory
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteTicketCategory(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTicketCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TicketCategories
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<TicketCategory>>> TicketCategories(
        [FromQuery()] TicketCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.TicketCategories(filter));
    }

    /// <summary>
    /// Get one TicketCategory
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<TicketCategory>> TicketCategory(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TicketCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about TicketCategory records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TicketCategoriesMeta(
        [FromQuery()] TicketCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.TicketCategoriesMeta(filter));
    }

    /// <summary>
    /// Connect multiple TicketCriteria records to TicketCategory
    /// </summary>
    [HttpPost("{Id}/ticketCriteria")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectTicketCriteria(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId,
        [FromQuery()] TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        try
        {
            await _service.ConnectTicketCriteria(uniqueId, ticketCriteriaId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple TicketCriteria records from TicketCategory
    /// </summary>
    [HttpDelete("{Id}/ticketCriteria")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectTicketCriteria(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId,
        [FromBody()] TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        try
        {
            await _service.DisconnectTicketCriteria(uniqueId, ticketCriteriaId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple TicketCriteria records for TicketCategory
    /// </summary>
    [HttpGet("{Id}/ticketCriteria")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<TicketCriterion>>> FindTicketCriteria(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId,
        [FromQuery()] TicketCriterionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindTicketCriteria(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple TicketCriteria records for TicketCategory
    /// </summary>
    [HttpPatch("{Id}/ticketCriteria")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTicketCriteria(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId,
        [FromBody()] TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        try
        {
            await _service.UpdateTicketCriteria(uniqueId, ticketCriteriaId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one TicketCategory
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTicketCategory(
        [FromRoute()] TicketCategoryWhereUniqueInput uniqueId,
        [FromQuery()] TicketCategoryUpdateInput ticketCategoryUpdateDto
    )
    {
        try
        {
            await _service.UpdateTicketCategory(uniqueId, ticketCategoryUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
