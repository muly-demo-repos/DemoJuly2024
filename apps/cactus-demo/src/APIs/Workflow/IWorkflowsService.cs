using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IWorkflowsService
{
    /// <summary>
    /// Create one Workflow
    /// </summary>
    public Task<Workflow> CreateWorkflow(WorkflowCreateInput workflow);

    /// <summary>
    /// Delete one Workflow
    /// </summary>
    public Task DeleteWorkflow(WorkflowWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Workflows
    /// </summary>
    public Task<List<Workflow>> Workflows(WorkflowFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Workflow
    /// </summary>
    public Task<Workflow> Workflow(WorkflowWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Workflow
    /// </summary>
    public Task UpdateWorkflow(WorkflowWhereUniqueInput uniqueId, WorkflowUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Workflows On Event Types records to Workflow
    /// </summary>
    public Task ConnectWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Connect multiple Workflow Step records to Workflow
    /// </summary>
    public Task ConnectWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Workflow
    /// </summary>
    public Task DisconnectWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Disconnect multiple Workflow Step records from Workflow
    /// </summary>
    public Task DisconnectWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );

    /// <summary>
    /// Find multiple Workflows On Event Types records for Workflow
    /// </summary>
    public Task<List<WorkflowsOnEventType>> FindWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeFindManyArgs WorkflowsOnEventTypeFindManyArgs
    );

    /// <summary>
    /// Find multiple Workflow Step records for Workflow
    /// </summary>
    public Task<List<WorkflowStep>> FindWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepFindManyArgs WorkflowStepFindManyArgs
    );

    /// <summary>
    /// Get a Users record for Workflow
    /// </summary>
    public Task<User> GetUsers(WorkflowWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Workflow records
    /// </summary>
    public Task<MetadataDto> WorkflowsMeta(WorkflowFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Workflows On Event Types records for Workflow
    /// </summary>
    public Task UpdateWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Update multiple Workflow Step records for Workflow
    /// </summary>
    public Task UpdateWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );
}
