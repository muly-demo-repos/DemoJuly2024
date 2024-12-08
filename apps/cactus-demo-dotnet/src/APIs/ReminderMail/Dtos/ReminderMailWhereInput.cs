using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class ReminderMailWhereInput
{
    public int? Id { get; set; }

    public int? ReferenceId { get; set; }

    public ReminderTypeEnum? ReminderType { get; set; }

    public int? ElapsedMinutes { get; set; }

    public DateTime? CreatedAt { get; set; }
}
