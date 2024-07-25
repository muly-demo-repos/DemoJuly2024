using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ReminderMailsControllerBase : ControllerBase
{
    protected readonly IReminderMailsService _service;

    public ReminderMailsControllerBase(IReminderMailsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Reminder Mail
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ReminderMail>> CreateReminderMail(ReminderMailCreateInput input)
    {
        var reminderMail = await _service.CreateReminderMail(input);

        return CreatedAtAction(nameof(ReminderMail), new { id = reminderMail.Id }, reminderMail);
    }

    /// <summary>
    /// Delete one Reminder Mail
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteReminderMail(
        [FromRoute()] ReminderMailWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteReminderMail(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ReminderMails
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ReminderMail>>> ReminderMails(
        [FromQuery()] ReminderMailFindManyArgs filter
    )
    {
        return Ok(await _service.ReminderMails(filter));
    }

    /// <summary>
    /// Get one Reminder Mail
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ReminderMail>> ReminderMail(
        [FromRoute()] ReminderMailWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ReminderMail(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Reminder Mail records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ReminderMailsMeta(
        [FromQuery()] ReminderMailFindManyArgs filter
    )
    {
        return Ok(await _service.ReminderMailsMeta(filter));
    }

    /// <summary>
    /// Update one Reminder Mail
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateReminderMail(
        [FromRoute()] ReminderMailWhereUniqueInput uniqueId,
        [FromQuery()] ReminderMailUpdateInput reminderMailUpdateDto
    )
    {
        try
        {
            await _service.UpdateReminderMail(uniqueId, reminderMailUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
