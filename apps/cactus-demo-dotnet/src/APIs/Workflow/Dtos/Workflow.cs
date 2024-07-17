using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class Workflow
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int User { get; set; }

    public TriggerEnum Trigger { get; set; }

    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public List<int>? Steps { get; set; }

    public List<int>? ActiveOn { get; set; }
}
