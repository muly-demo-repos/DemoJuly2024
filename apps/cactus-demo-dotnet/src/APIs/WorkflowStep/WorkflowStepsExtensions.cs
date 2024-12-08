using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class WorkflowStepsExtensions
{
    public static WorkflowStep ToDto(this WorkflowStepDbModel model)
    {
        return new WorkflowStep
        {
            Id = model.Id,
            StepNumber = model.StepNumber,
            Action = model.Action,
            Workflow = model.WorkflowId,
            SendTo = model.SendTo,
            ReminderBody = model.ReminderBody,
            EmailSubject = model.EmailSubject,
            Template = model.Template,
            WorkflowReminders = model.WorkflowReminders?.Select(x => x.Id).ToList(),
        };
    }

    public static WorkflowStepDbModel ToModel(
        this WorkflowStepUpdateInput updateDto,
        WorkflowStepWhereUniqueInput uniqueId
    )
    {
        var workflowStep = new WorkflowStepDbModel
        {
            Id = uniqueId.Id,
            SendTo = updateDto.SendTo,
            ReminderBody = updateDto.ReminderBody,
            EmailSubject = updateDto.EmailSubject
        };

        // map required fields
        if (updateDto.StepNumber != null)
        {
            workflowStep.StepNumber = updateDto.StepNumber.Value;
        }
        if (updateDto.Action != null)
        {
            workflowStep.Action = updateDto.Action.Value;
        }
        if (updateDto.Workflow != null)
        {
            workflowStep.Workflow = updateDto.Workflow.Value;
        }
        if (updateDto.Template != null)
        {
            workflowStep.Template = updateDto.Template.Value;
        }

        return workflowStep;
    }
}
