using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class WorkflowsOnEventTypesExtensions
{
    public static WorkflowsOnEventType ToDto(this WorkflowsOnEventTypeDbModel model)
    {
        return new WorkflowsOnEventType
        {
            Id = model.Id,
            EventType = model.EventTypeId,
            Workflow = model.WorkflowId,
        };
    }

    public static WorkflowsOnEventTypeDbModel ToModel(
        this WorkflowsOnEventTypeUpdateInput updateDto,
        WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        var workflowsOnEventType = new WorkflowsOnEventTypeDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.EventType != null)
        {
            workflowsOnEventType.EventType = updateDto.EventType.Value;
        }
        if (updateDto.Workflow != null)
        {
            workflowsOnEventType.Workflow = updateDto.Workflow.Value;
        }

        return workflowsOnEventType;
    }
}
