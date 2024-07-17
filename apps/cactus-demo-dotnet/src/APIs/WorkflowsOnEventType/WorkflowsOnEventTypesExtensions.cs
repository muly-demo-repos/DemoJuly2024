using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class WorkflowsOnEventTypesExtensions
{
    public static WorkflowsOnEventType ToDto(this WorkflowsOnEventTypeDbModel model)
    {
        return new WorkflowsOnEventType
        {
            Id = model.Id,
            Workflow = model.WorkflowId,
            EventType = model.EventTypeId,
        };
    }

    public static WorkflowsOnEventTypeDbModel ToModel(
        this WorkflowsOnEventTypeUpdateInput updateDto,
        WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        var workflowsOnEventType = new WorkflowsOnEventTypeDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Workflow != null)
        {
            workflowsOnEventType.Workflow = updateDto.Workflow.Value;
        }
        if (updateDto.EventType != null)
        {
            workflowsOnEventType.EventType = updateDto.EventType.Value;
        }

        return workflowsOnEventType;
    }
}
