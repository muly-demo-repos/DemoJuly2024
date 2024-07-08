using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;

namespace QaService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TicketCriteriaControllerBase : ControllerBase
{
    protected readonly ITicketCriteriaService _service;

    public TicketCriteriaControllerBase(ITicketCriteriaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TicketCriteria
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<TicketCriterion>> CreateTicketCriterion(
        TicketCriterionCreateInput input
    )
    {
        var ticketCriterion = await _service.CreateTicketCriterion(input);

        return CreatedAtAction(
            nameof(TicketCriterion),
            new { id = ticketCriterion.Id },
            ticketCriterion
        );
    }

    /// <summary>
    /// Delete one TicketCriteria
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteTicketCriterion(
        [FromRoute()] TicketCriterionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTicketCriterion(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TicketCriteria
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<TicketCriterion>>> TicketCriteria(
        [FromQuery()] TicketCriterionFindManyArgs filter
    )
    {
        return Ok(await _service.TicketCriteria(filter));
    }

    /// <summary>
    /// Get one TicketCriteria
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<TicketCriterion>> TicketCriterion(
        [FromRoute()] TicketCriterionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TicketCriterion(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Ticket Category record for TicketCriteria
    /// </summary>
    [HttpGet("{Id}/ticketCategories")]
    public async Task<ActionResult<List<TicketCategory>>> GetTicketCategory(
        [FromRoute()] TicketCriterionWhereUniqueInput uniqueId
    )
    {
        var ticketCategory = await _service.GetTicketCategory(uniqueId);
        return Ok(ticketCategory);
    }

    /// <summary>
    /// Meta data about TicketCriteria records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TicketCriteriaMeta(
        [FromQuery()] TicketCriterionFindManyArgs filter
    )
    {
        return Ok(await _service.TicketCriteriaMeta(filter));
    }

    /// <summary>
    /// Update one TicketCriteria
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTicketCriterion(
        [FromRoute()] TicketCriterionWhereUniqueInput uniqueId,
        [FromQuery()] TicketCriterionUpdateInput ticketCriterionUpdateDto
    )
    {
        try
        {
            await _service.UpdateTicketCriterion(uniqueId, ticketCriterionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
