using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IWorkflowRemindersService
{
    /// <summary>
    /// Create one Workflow Reminder
    /// </summary>
    public Task<WorkflowReminder> CreateWorkflowReminder(
        WorkflowReminderCreateInput workflowreminder
    );

    /// <summary>
    /// Delete one Workflow Reminder
    /// </summary>
    public Task DeleteWorkflowReminder(WorkflowReminderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WorkflowReminders
    /// </summary>
    public Task<List<WorkflowReminder>> WorkflowReminders(
        WorkflowReminderFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one Workflow Reminder
    /// </summary>
    public Task<WorkflowReminder> WorkflowReminder(WorkflowReminderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Workflow Reminder
    /// </summary>
    public Task UpdateWorkflowReminder(
        WorkflowReminderWhereUniqueInput uniqueId,
        WorkflowReminderUpdateInput updateDto
    );

    /// <summary>
    /// Get a Booking record for Workflow Reminder
    /// </summary>
    public Task<Booking> GetBooking(WorkflowReminderWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Workflow Step record for Workflow Reminder
    /// </summary>
    public Task<WorkflowStep> GetWorkflowStep(WorkflowReminderWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Workflow Reminder records
    /// </summary>
    public Task<MetadataDto> WorkflowRemindersMeta(WorkflowReminderFindManyArgs findManyArgs);
}
