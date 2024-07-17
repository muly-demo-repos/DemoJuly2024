using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IWorkflowsOnEventTypesService
{
    /// <summary>
    /// Create one Workflows On Event Type
    /// </summary>
    public Task<WorkflowsOnEventType> CreateWorkflowsOnEventType(
        WorkflowsOnEventTypeCreateInput workflowsoneventtype
    );

    /// <summary>
    /// Delete one Workflows On Event Type
    /// </summary>
    public Task DeleteWorkflowsOnEventType(WorkflowsOnEventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WorkflowsOnEventTypes
    /// </summary>
    public Task<List<WorkflowsOnEventType>> WorkflowsOnEventTypes(
        WorkflowsOnEventTypeFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Workflows On Event Type
    /// </summary>
    public Task<WorkflowsOnEventType> WorkflowsOnEventType(
        WorkflowsOnEventTypeWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one Workflows On Event Type
    /// </summary>
    public Task UpdateWorkflowsOnEventType(
        WorkflowsOnEventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeUpdateInput updateDto
    );

    /// <summary>
    /// Get a Event Type record for Workflows On Event Type
    /// </summary>
    public Task<EventType> GetEventType(WorkflowsOnEventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Workflow record for Workflows On Event Type
    /// </summary>
    public Task<Workflow> GetWorkflow(WorkflowsOnEventTypeWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Workflows On Event Type records
    /// </summary>
    public Task<MetadataDto> WorkflowsOnEventTypesMeta(
        WorkflowsOnEventTypeFindManyArgs findManyArgs
    );
}
