using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IWorkflowStepsService
{
    /// <summary>
    /// Create one Workflow Step
    /// </summary>
    public Task<WorkflowStep> CreateWorkflowStep(WorkflowStepCreateInput workflowstep);

    /// <summary>
    /// Delete one Workflow Step
    /// </summary>
    public Task DeleteWorkflowStep(WorkflowStepWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WorkflowSteps
    /// </summary>
    public Task<List<WorkflowStep>> WorkflowSteps(WorkflowStepFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Workflow Step
    /// </summary>
    public Task<WorkflowStep> WorkflowStep(WorkflowStepWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Workflow Step
    /// </summary>
    public Task UpdateWorkflowStep(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowStepUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple Workflow Reminder records to Workflow Step
    /// </summary>
    public Task ConnectWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Disconnect multiple Workflow Reminder records from Workflow Step
    /// </summary>
    public Task DisconnectWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );

    /// <summary>
    /// Find multiple Workflow Reminder records for Workflow Step
    /// </summary>
    public Task<List<WorkflowReminder>> FindWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderFindManyArgs WorkflowReminderFindManyArgs
    );

    /// <summary>
    /// Get a Workflow record for Workflow Step
    /// </summary>
    public Task<Workflow> GetWorkflow(WorkflowStepWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Workflow Step records
    /// </summary>
    public Task<MetadataDto> WorkflowStepsMeta(WorkflowStepFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Workflow Reminder records for Workflow Step
    /// </summary>
    public Task UpdateWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    );
}
