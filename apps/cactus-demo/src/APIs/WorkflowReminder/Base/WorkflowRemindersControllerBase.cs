using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkflowRemindersControllerBase : ControllerBase
{
    protected readonly IWorkflowRemindersService _service;

    public WorkflowRemindersControllerBase(IWorkflowRemindersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Workflow Reminder
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkflowReminder>> CreateWorkflowReminder(
        WorkflowReminderCreateInput input
    )
    {
        var workflowReminder = await _service.CreateWorkflowReminder(input);

        return CreatedAtAction(
            nameof(WorkflowReminder),
            new { id = workflowReminder.Id },
            workflowReminder
        );
    }

    /// <summary>
    /// Delete one Workflow Reminder
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkflowReminder(
        [FromRoute()] WorkflowReminderWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkflowReminder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WorkflowReminders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkflowReminder>>> WorkflowReminders(
        [FromQuery()] WorkflowReminderFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowReminders(filter));
    }

    /// <summary>
    /// Get one Workflow Reminder
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkflowReminder>> WorkflowReminder(
        [FromRoute()] WorkflowReminderWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkflowReminder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Workflow Reminder
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkflowReminder(
        [FromRoute()] WorkflowReminderWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderUpdateInput workflowReminderUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkflowReminder(uniqueId, workflowReminderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Booking record for Workflow Reminder
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] WorkflowReminderWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Get a Workflow Step record for Workflow Reminder
    /// </summary>
    [HttpGet("{Id}/workflowSteps")]
    public async Task<ActionResult<List<WorkflowStep>>> GetWorkflowStep(
        [FromRoute()] WorkflowReminderWhereUniqueInput uniqueId
    )
    {
        var workflowStep = await _service.GetWorkflowStep(uniqueId);
        return Ok(workflowStep);
    }

    /// <summary>
    /// Meta data about Workflow Reminder records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkflowRemindersMeta(
        [FromQuery()] WorkflowReminderFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowRemindersMeta(filter));
    }
}
