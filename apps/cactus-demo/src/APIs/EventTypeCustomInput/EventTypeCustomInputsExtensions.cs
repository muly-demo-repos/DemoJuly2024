using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class EventTypeCustomInputsExtensions
{
    public static EventTypeCustomInput ToDto(this EventTypeCustomInputDbModel model)
    {
        return new EventTypeCustomInput
        {
            Id = model.Id,
            Label = model.Label,
            Type = model.Type,
            Required = model.Required,
            Placeholder = model.Placeholder,
            EventType = model.EventTypeId,
        };
    }

    public static EventTypeCustomInputDbModel ToModel(
        this EventTypeCustomInputUpdateInput updateDto,
        EventTypeCustomInputWhereUniqueInput uniqueId
    )
    {
        var eventTypeCustomInput = new EventTypeCustomInputDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Label != null)
        {
            eventTypeCustomInput.Label = updateDto.Label;
        }
        if (updateDto.Type != null)
        {
            eventTypeCustomInput.Type = updateDto.Type.Value;
        }
        if (updateDto.Required != null)
        {
            eventTypeCustomInput.Required = updateDto.Required.Value;
        }
        if (updateDto.Placeholder != null)
        {
            eventTypeCustomInput.Placeholder = updateDto.Placeholder;
        }
        if (updateDto.EventType != null)
        {
            eventTypeCustomInput.EventType = updateDto.EventType.Value;
        }

        return eventTypeCustomInput;
    }
}
