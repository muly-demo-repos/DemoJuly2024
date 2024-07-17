using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class CredentialsExtensions
{
    public static Credential ToDto(this CredentialDbModel model)
    {
        return new Credential
        {
            Id = model.Id,
            TypeField = model.TypeField,
            Key = model.Key,
            User = model.UserId,
            AppField = model.AppFieldId,
            DestinationCalendars = model.DestinationCalendars?.Select(x => x.Id).ToList(),
        };
    }

    public static CredentialDbModel ToModel(
        this CredentialUpdateInput updateDto,
        CredentialWhereUniqueInput uniqueId
    )
    {
        var credential = new CredentialDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.TypeField != null)
        {
            credential.TypeField = updateDto.TypeField;
        }
        if (updateDto.Key != null)
        {
            credential.Key = updateDto.Key;
        }

        return credential;
    }
}
