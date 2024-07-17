using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

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
    /// Connect multiple Active On records to Workflow
    /// </summary>
    public Task ConnectActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Connect multiple Steps records to Workflow
    /// </summary>
    public Task ConnectSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );

    /// <summary>
    /// Disconnect multiple Active On records from Workflow
    /// </summary>
    public Task DisconnectActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Disconnect multiple Steps records from Workflow
    /// </summary>
    public Task DisconnectSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );

    /// <summary>
    /// Find multiple Active On records for Workflow
    /// </summary>
    public Task<List<WorkflowsOnEventType>> FindActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeFindManyArgs WorkflowsOnEventTypeFindManyArgs
    );

    /// <summary>
    /// Find multiple Steps records for Workflow
    /// </summary>
    public Task<List<WorkflowStep>> FindSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepFindManyArgs WorkflowStepFindManyArgs
    );

    /// <summary>
    /// Get a User record for Workflow
    /// </summary>
    public Task<User> GetUser(WorkflowWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Workflow records
    /// </summary>
    public Task<MetadataDto> WorkflowsMeta(WorkflowFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Active On records for Workflow
    /// </summary>
    public Task UpdateActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    );

    /// <summary>
    /// Update multiple Steps records for Workflow
    /// </summary>
    public Task UpdateSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    );
}
