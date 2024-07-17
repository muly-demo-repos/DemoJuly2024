using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class SchedulesExtensions
{
    public static Schedule ToDto(this ScheduleDbModel model)
    {
        return new Schedule
        {
            Id = model.Id,
            User = model.UserId,
            Name = model.Name,
            TimeZone = model.TimeZone,
            EventType = model.EventType?.Select(x => x.Id).ToList(),
            Availability = model.Availability?.Select(x => x.Id).ToList(),
        };
    }

    public static ScheduleDbModel ToModel(
        this ScheduleUpdateInput updateDto,
        ScheduleWhereUniqueInput uniqueId
    )
    {
        var schedule = new ScheduleDbModel { Id = uniqueId.Id, TimeZone = updateDto.TimeZone };

        // map required fields
        if (updateDto.User != null)
        {
            schedule.User = updateDto.User.Value;
        }
        if (updateDto.Name != null)
        {
            schedule.Name = updateDto.Name;
        }

        return schedule;
    }
}
