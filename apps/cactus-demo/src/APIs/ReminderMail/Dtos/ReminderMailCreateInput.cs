using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class ReminderMailCreateInput
{
    public int? Id { get; set; }

    public int ReferenceId { get; set; }

    public ReminderTypeEnum ReminderType { get; set; }

    public int ElapsedMinutes { get; set; }

    public DateTime CreatedAt { get; set; }
}
