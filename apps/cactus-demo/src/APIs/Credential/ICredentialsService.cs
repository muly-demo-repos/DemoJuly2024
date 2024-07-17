using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface ICredentialsService
{
    /// <summary>
    /// Create one Credential
    /// </summary>
    public Task<Credential> CreateCredential(CredentialCreateInput credential);

    /// <summary>
    /// Connect multiple Destination Calendar records to Credential
    /// </summary>
    public Task ConnectDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    );

    /// <summary>
    /// Disconnect multiple Destination Calendar records from Credential
    /// </summary>
    public Task DisconnectDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    );

    /// <summary>
    /// Find multiple Destination Calendar records for Credential
    /// </summary>
    public Task<List<DestinationCalendar>> FindDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarFindManyArgs DestinationCalendarFindManyArgs
    );

    /// <summary>
    /// Get a App Field record for Credential
    /// </summary>
    public Task<AppModel> GetAppField(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Users record for Credential
    /// </summary>
    public Task<User> GetUsers(CredentialWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Credential records
    /// </summary>
    public Task<MetadataDto> CredentialsMeta(CredentialFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Destination Calendar records for Credential
    /// </summary>
    public Task UpdateDestinationCalendar(
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
