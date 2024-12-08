using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IReminderMailsService
{
    /// <summary>
    /// Create one Reminder Mail
    /// </summary>
    public Task<ReminderMail> CreateReminderMail(ReminderMailCreateInput remindermail);

    /// <summary>
    /// Delete one Reminder Mail
    /// </summary>
    public Task DeleteReminderMail(ReminderMailWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ReminderMails
    /// </summary>
    public Task<List<ReminderMail>> ReminderMails(ReminderMailFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Reminder Mail
    /// </summary>
    public Task<ReminderMail> ReminderMail(ReminderMailWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Reminder Mail records
    /// </summary>
    public Task<MetadataDto> ReminderMailsMeta(ReminderMailFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Reminder Mail
    /// </summary>
    public Task UpdateReminderMail(
        ReminderMailWhereUniqueInput uniqueId,
        ReminderMailUpdateInput updateDto
    );
}
