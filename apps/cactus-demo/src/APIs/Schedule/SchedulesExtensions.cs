using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class SchedulesExtensions
{
    public static Schedule ToDto(this ScheduleDbModel model)
    {
        return new Schedule
        {
            Id = model.Id,
            Name = model.Name,
            TimeZone = model.TimeZone,
            Users = model.UsersId,
            Availability = model.Availability?.Select(x => x.Id).ToList(),
            EventType = model.EventType?.Select(x => x.Id).ToList(),
        };
    }

    public static ScheduleDbModel ToModel(
        this ScheduleUpdateInput updateDto,
        ScheduleWhereUniqueInput uniqueId
    )
    {
        var schedule = new ScheduleDbModel { Id = uniqueId.Id, TimeZone = updateDto.TimeZone };

        // map required fields
        if (updateDto.Name != null)
        {
            schedule.Name = updateDto.Name;
        }
        if (updateDto.Users != null)
        {
            schedule.Users = updateDto.Users.Value;
        }

        return schedule;
    }
}
