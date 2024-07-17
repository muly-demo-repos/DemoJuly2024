using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TeamsControllerBase : ControllerBase
{
    protected readonly ITeamsService _service;

    public TeamsControllerBase(ITeamsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Team
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Team>> CreateTeam(TeamCreateInput input)
    {
        var team = await _service.CreateTeam(input);

        return CreatedAtAction(nameof(Team), new { id = team.Id }, team);
    }

    /// <summary>
    /// Delete one Team
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTeam([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTeam(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Teams
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Team>>> Teams([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.Teams(filter));
    }

    /// <summary>
    /// Get one Team
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Team>> Team([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Team(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple Event Type records to Team
    /// </summary>
    [HttpPost("{Id}/eventTypes")]
    public async Task<ActionResult> ConnectEventType(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.ConnectEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Membership records to Team
    /// </summary>
    [HttpPost("{Id}/memberships")]
    public async Task<ActionResult> ConnectMembership(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.ConnectMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from Team
    /// </summary>
    [HttpDelete("{Id}/eventTypes")]
    public async Task<ActionResult> DisconnectEventType(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.DisconnectEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Membership records from Team
    /// </summary>
    [HttpDelete("{Id}/memberships")]
    public async Task<ActionResult> DisconnectMembership(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.DisconnectMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Event Type records for Team
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> FindEventType(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEventType(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Membership records for Team
    /// </summary>
    [HttpGet("{Id}/memberships")]
    public async Task<ActionResult<List<Membership>>> FindMembership(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMembership(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TeamsMeta([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.TeamsMeta(filter));
    }

    /// <summary>
    /// Update multiple Event Type records for Team
    /// </summary>
    [HttpPatch("{Id}/eventTypes")]
    public async Task<ActionResult> UpdateEventType(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.UpdateEventType(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Membership records for Team
    /// </summary>
    [HttpPatch("{Id}/memberships")]
    public async Task<ActionResult> UpdateMembership(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.UpdateMembership(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTeam(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] TeamUpdateInput teamUpdateDto
    )
    {
        try
        {
            await _service.UpdateTeam(uniqueId, teamUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
