using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CredentialsControllerBase : ControllerBase
{
    protected readonly ICredentialsService _service;

    public CredentialsControllerBase(ICredentialsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Credential
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Credential>> CreateCredential(CredentialCreateInput input)
    {
        var credential = await _service.CreateCredential(input);

        return CreatedAtAction(nameof(Credential), new { id = credential.Id }, credential);
    }

    /// <summary>
    /// Connect multiple Destination Calendar records to Credential
    /// </summary>
    [HttpPost("{Id}/destinationCalendars")]
    public async Task<ActionResult> ConnectDestinationCalendar(
        [FromRoute()] CredentialWhereUniqueInput uniqueId,
        [FromQuery()] DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        try
        {
            await _service.ConnectDestinationCalendar(uniqueId, destinationCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Destination Calendar records from Credential
    /// </summary>
    [HttpDelete("{Id}/destinationCalendars")]
    public async Task<ActionResult> DisconnectDestinationCalendar(
        [FromRoute()] CredentialWhereUniqueInput uniqueId,
        [FromBody()] DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        try
        {
            await _service.DisconnectDestinationCalendar(uniqueId, destinationCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Destination Calendar records for Credential
    /// </summary>
    [HttpGet("{Id}/destinationCalendars")]
    public async Task<ActionResult<List<DestinationCalendar>>> FindDestinationCalendar(
        [FromRoute()] CredentialWhereUniqueInput uniqueId,
        [FromQuery()] DestinationCalendarFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindDestinationCalendar(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a App Field record for Credential
    /// </summary>
    [HttpGet("{Id}/appModels")]
    public async Task<ActionResult<List<AppModel>>> GetAppField(
        [FromRoute()] CredentialWhereUniqueInput uniqueId
    )
    {
        var appModel = await _service.GetAppModel(uniqueId);
        return Ok(appModel);
    }

    /// <summary>
    /// Get a Users record for Credential
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
        [FromRoute()] CredentialWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Credential records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CredentialsMeta(
        [FromQuery()] CredentialFindManyArgs filter
    )
    {
        return Ok(await _service.CredentialsMeta(filter));
    }

    /// <summary>
    /// Update multiple Destination Calendar records for Credential
    /// </summary>
    [HttpPatch("{Id}/destinationCalendars")]
    public async Task<ActionResult> UpdateDestinationCalendar(
        [FromRoute()] CredentialWhereUniqueInput uniqueId,
        [FromBody()] DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        try
        {
            await _service.UpdateDestinationCalendar(uniqueId, destinationCalendarsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Delete one Credential
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCredential(
        [FromRoute()] CredentialWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCredential(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Credentials
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Credential>>> Credentials(
        [FromQuery()] CredentialFindManyArgs filter
    )
    {
        return Ok(await _service.Credentials(filter));
    }

    /// <summary>
    /// Get one Credential
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Credential>> Credential(
        [FromRoute()] CredentialWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Credential(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Credential
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCredential(
        [FromRoute()] CredentialWhereUniqueInput uniqueId,
        [FromQuery()] CredentialUpdateInput credentialUpdateDto
    )
    {
        try
        {
            await _service.UpdateCredential(uniqueId, credentialUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
