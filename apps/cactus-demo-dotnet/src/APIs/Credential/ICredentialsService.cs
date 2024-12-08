using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface ICredentialsService
{
    /// <summary>
    /// Create one Credential
    /// </summary>
    public Task<Credential> CreateCredential(CredentialCreateInput credential);

    /// <summary>
    /// Connect multiple Destination Calendars records to Credential
    /// </summary>
    public Task ConnectDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    );

    /// <summary>
    /// Disconnect multiple Destination Calendars records from Credential
    /// </summary>
    public Task DisconnectDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    );

    /// <summary>
    /// Find multiple Destination Calendars records for Credential
    /// </summary>
    public Task<List<DestinationCalendar>> FindDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarFindManyArgs DestinationCalendarFindManyArgs
    );

    /// <summary>
    /// Get a App Field record for Credential
    /// </summary>
    public Task<AppModel> GetAppField(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Credential
    /// </summary>
    public Task<User> GetUser(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Credential records
    /// </summary>
    public Task<MetadataDto> CredentialsMeta(CredentialFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Destination Calendars records for Credential
    /// </summary>
    public Task UpdateDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    );

    /// <summary>
    /// Delete one Credential
    /// </summary>
    public Task DeleteCredential(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Credentials
    /// </summary>
    public Task<List<Credential>> Credentials(CredentialFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Credential
    /// </summary>
    public Task<Credential> Credential(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Credential
    /// </summary>
    public Task UpdateCredential(
        CredentialWhereUniqueInput uniqueId,
        CredentialUpdateInput updateDto
    );
}
