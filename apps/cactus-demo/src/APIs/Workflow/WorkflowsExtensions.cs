using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class WorkflowsExtensions
{
    public static Workflow ToDto(this WorkflowDbModel model)
    {
        return new Workflow
        {
            Id = model.Id,
            Name = model.Name,
            Trigger = model.Trigger,
            Time = model.Time,
            TimeUnit = model.TimeUnit,
            Users = model.UsersId,
            WorkflowStep = model.WorkflowStep?.Select(x => x.Id).ToList(),
            WorkflowsOnEventTypes = model.WorkflowsOnEventTypes?.Select(x => x.Id).ToList(),
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
        if (updateDto.Trigger != null)
        {
            workflow.Trigger = updateDto.Trigger.Value;
        }
        if (updateDto.Users != null)
        {
            workflow.Users = updateDto.Users.Value;
        }

        return workflow;
    }
}
