using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class AvailabilitiesExtensions
{
    public static Availability ToDto(this AvailabilityDbModel model)
    {
        return new Availability
        {
            Id = model.Id,
            Days = model.Days,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Date = model.Date,
            EventType = model.EventTypeId,
            Schedule = model.ScheduleId,
            Users = model.UsersId,
        };
    }

    public static AvailabilityDbModel ToModel(
        this AvailabilityUpdateInput updateDto,
        AvailabilityWhereUniqueInput uniqueId
    )
    {
        var availability = new AvailabilityDbModel { Id = uniqueId.Id, Date = updateDto.Date };

        // map required fields
        if (updateDto.Days != null)
        {
            availability.Days = updateDto.Days.Value;
        }
        if (updateDto.StartTime != null)
        {
            availability.StartTime = updateDto.StartTime.Value;
        }
        if (updateDto.EndTime != null)
        {
            availability.EndTime = updateDto.EndTime.Value;
        }

        return availability;
    }
}
