using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class WorkflowsExtensions
{
    public static Workflow ToDto(this WorkflowDbModel model)
    {
        return new Workflow
        {
            Id = model.Id,
            Name = model.Name,
            User = model.UserId,
            Trigger = model.Trigger,
            Time = model.Time,
            TimeUnit = model.TimeUnit,
            Steps = model.Steps?.Select(x => x.Id).ToList(),
            ActiveOn = model.ActiveOn?.Select(x => x.Id).ToList(),
        };
    }

    public static WorkflowDbModel ToModel(
        this WorkflowUpdateInput updateDto,
        WorkflowWhereUniqueInput uniqueId
    )
    {
        var workflow = new WorkflowDbModel
        {
            Id = uniqueId.Id,
            Time = updateDto.Time,
            TimeUnit = updateDto.TimeUnit
        };

        // map required fields
        if (updateDto.Name != null)
        {
            workflow.Name = updateDto.Name;
        }
        if (updateDto.User != null)
        {
            workflow.User = updateDto.User.Value;
        }
        if (updateDto.Trigger != null)
        {
            workflow.Trigger = updateDto.Trigger.Value;
        }

        return workflow;
    }
}
