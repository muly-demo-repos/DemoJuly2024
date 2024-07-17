using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkflowStepsControllerBase : ControllerBase
{
    protected readonly IWorkflowStepsService _service;

    public WorkflowStepsControllerBase(IWorkflowStepsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Workflow Step
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkflowStep>> CreateWorkflowStep(WorkflowStepCreateInput input)
    {
        var workflowStep = await _service.CreateWorkflowStep(input);

        return CreatedAtAction(nameof(WorkflowStep), new { id = workflowStep.Id }, workflowStep);
    }

    /// <summary>
    /// Delete one Workflow Step
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkflowStep(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkflowStep(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WorkflowSteps
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkflowStep>>> WorkflowSteps(
        [FromQuery()] WorkflowStepFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowSteps(filter));
    }

    /// <summary>
    /// Get one Workflow Step
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkflowStep>> WorkflowStep(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkflowStep(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Workflow Step
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkflowStep(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowStepUpdateInput workflowStepUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkflowStep(uniqueId, workflowStepUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Workflow Reminder records to Workflow Step
    /// </summary>
    [HttpPost("{Id}/workflowReminders")]
    public async Task<ActionResult> ConnectWorkflowReminder(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.ConnectWorkflowReminder(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflow Reminder records from Workflow Step
    /// </summary>
    [HttpDelete("{Id}/workflowReminders")]
    public async Task<ActionResult> DisconnectWorkflowReminder(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.DisconnectWorkflowReminder(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Workflow Reminder records for Workflow Step
    /// </summary>
    [HttpGet("{Id}/workflowReminders")]
    public async Task<ActionResult<List<WorkflowReminder>>> FindWorkflowReminder(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowReminderFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowReminder(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Workflow record for Workflow Step
    /// </summary>
    [HttpGet("{Id}/workflows")]
    public async Task<ActionResult<List<Workflow>>> GetWorkflow(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId
    )
    {
        var workflow = await _service.GetWorkflow(uniqueId);
        return Ok(workflow);
    }

    /// <summary>
    /// Meta data about Workflow Step records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkflowStepsMeta(
        [FromQuery()] WorkflowStepFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowStepsMeta(filter));
    }

    /// <summary>
    /// Update multiple Workflow Reminder records for Workflow Step
    /// </summary>
    [HttpPatch("{Id}/workflowReminders")]
    public async Task<ActionResult> UpdateWorkflowReminder(
        [FromRoute()] WorkflowStepWhereUniqueInput uniqueId,
        [FromBody()] WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        try
        {
            await _service.UpdateWorkflowReminder(uniqueId, workflowRemindersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
