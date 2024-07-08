using QaService.APIs.Dtos;
using QaService.Infrastructure.Models;

namespace QaService.APIs.Extensions;

public static class ProcessingAuditsExtensions
{
    public static ProcessingAudit ToDto(this ProcessingAuditDbModel model)
    {
        return new ProcessingAudit
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            TicketNumber = model.TicketNumber,
            TypeField = model.TypeField,
            Subtype = model.Subtype,
            Item = model.Item,
            Criteria = model.Criteria,
            Result = model.Result,
        };
    }

    public static ProcessingAuditDbModel ToModel(
        this ProcessingAuditUpdateInput updateDto,
        ProcessingAuditWhereUniqueInput uniqueId
    )
    {
        var processingAudit = new ProcessingAuditDbModel
        {
            Id = uniqueId.Id,
            TicketNumber = updateDto.TicketNumber,
            TypeField = updateDto.TypeField,
            Subtype = updateDto.Subtype,
            Item = updateDto.Item,
            Criteria = updateDto.Criteria,
            Result = updateDto.Result
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            processingAudit.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            processingAudit.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return processingAudit;
    }
}
