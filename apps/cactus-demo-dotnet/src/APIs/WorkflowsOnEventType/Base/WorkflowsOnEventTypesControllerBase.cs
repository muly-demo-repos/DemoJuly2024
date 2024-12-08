using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkflowsOnEventTypesControllerBase : ControllerBase
{
    protected readonly IWorkflowsOnEventTypesService _service;

    public WorkflowsOnEventTypesControllerBase(IWorkflowsOnEventTypesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Workflows On Event Type
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkflowsOnEventType>> CreateWorkflowsOnEventType(
        WorkflowsOnEventTypeCreateInput input
    )
    {
        var workflowsOnEventType = await _service.CreateWorkflowsOnEventType(input);

        return CreatedAtAction(
            nameof(WorkflowsOnEventType),
            new { id = workflowsOnEventType.Id },
            workflowsOnEventType
        );
    }

    /// <summary>
    /// Delete one Workflows On Event Type
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkflowsOnEventType(
        [FromRoute()] WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkflowsOnEventType(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WorkflowsOnEventTypes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkflowsOnEventType>>> WorkflowsOnEventTypes(
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowsOnEventTypes(filter));
    }

    /// <summary>
    /// Get one Workflows On Event Type
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkflowsOnEventType>> WorkflowsOnEventType(
        [FromRoute()] WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkflowsOnEventType(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Workflows On Event Type
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkflowsOnEventType(
        [FromRoute()] WorkflowsOnEventTypeWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeUpdateInput workflowsOnEventTypeUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkflowsOnEventType(uniqueId, workflowsOnEventTypeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Event Type record for Workflows On Event Type
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Get a Workflow record for Workflows On Event Type
    /// </summary>
    [HttpGet("{Id}/workflows")]
    public async Task<ActionResult<List<Workflow>>> GetWorkflow(
        [FromRoute()] WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        var workflow = await _service.GetWorkflow(uniqueId);
        return Ok(workflow);
    }

    /// <summary>
    /// Meta data about Workflows On Event Type records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkflowsOnEventTypesMeta(
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowsOnEventTypesMeta(filter));
    }
}
