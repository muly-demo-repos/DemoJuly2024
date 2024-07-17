using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class CredentialsServiceBase : ICredentialsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public CredentialsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Credential
    /// </summary>
    public async Task<Credential> CreateCredential(CredentialCreateInput createDto)
    {
        var credential = new CredentialDbModel
        {
            TypeField = createDto.TypeField,
            Key = createDto.Key
        };

        if (createDto.Id != null)
        {
            credential.Id = createDto.Id.Value;
        }
        if (createDto.DestinationCalendars != null)
        {
            credential.DestinationCalendars = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto
                        .DestinationCalendars.Select(t => t.Id)
                        .Contains(destinationCalendar.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            credential.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.AppField != null)
        {
            credential.AppField = await _context
                .AppModels.Where(appModel => createDto.AppField.Id == appModel.Id)
                .FirstOrDefaultAsync();
        }

        _context.Credentials.Add(credential);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CredentialDbModel>(credential.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Connect multiple Destination Calendars records to Credential
    /// </summary>
    public async Task ConnectDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(x => x.DestinationCalendars)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        var destinationCalendars = await _context
            .DestinationCalendars.Where(t =>
                destinationCalendarsId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();
        if (destinationCalendars.Count == 0)
        {
            throw new NotFoundException();
        }

        var destinationCalendarsToConnect = destinationCalendars.Except(
            credential.DestinationCalendars
        );

        foreach (var destinationCalendar in destinationCalendarsToConnect)
        {
            credential.DestinationCalendars.Add(destinationCalendar);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Destination Calendars records from Credential
    /// </summary>
    public async Task DisconnectDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(x => x.DestinationCalendars)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        var destinationCalendars = await _context
            .DestinationCalendars.Where(t =>
                destinationCalendarsId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();

        foreach (var destinationCalendar in destinationCalendars)
        {
            credential.DestinationCalendars?.Remove(destinationCalendar);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Destination Calendars records for Credential
    /// </summary>
    public async Task<List<DestinationCalendar>> FindDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarFindManyArgs credentialFindManyArgs
    )
    {
        var destinationCalendars = await _context
            .DestinationCalendars.Where(m => m.CredentialId == uniqueId.Id)
            .ApplyWhere(credentialFindManyArgs.Where)
            .ApplySkip(credentialFindManyArgs.Skip)
            .ApplyTake(credentialFindManyArgs.Take)
            .ApplyOrderBy(credentialFindManyArgs.SortBy)
            .ToListAsync();

        return destinationCalendars.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a App Field record for Credential
    /// </summary>
    public async Task<AppModel> GetAppField(CredentialWhereUniqueInput uniqueId)
    {
        var credential = await _context
            .Credentials.Where(credential => credential.Id == uniqueId.Id)
            .Include(credential => credential.AppField)
            .FirstOrDefaultAsync();
        if (credential == null)
        {
            throw new NotFoundException();
        }
        return credential.AppField.ToDto();
    }

    /// <summary>
    /// Get a User record for Credential
    /// </summary>
    public async Task<User> GetUser(CredentialWhereUniqueInput uniqueId)
    {
        var credential = await _context
            .Credentials.Where(credential => credential.Id == uniqueId.Id)
            .Include(credential => credential.User)
            .FirstOrDefaultAsync();
        if (credential == null)
        {
            throw new NotFoundException();
        }
        return credential.User.ToDto();
    }

    /// <summary>
    /// Meta data about Credential records
    /// </summary>
    public async Task<MetadataDto> CredentialsMeta(CredentialFindManyArgs findManyArgs)
    {
        var count = await _context.Credentials.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Destination Calendars records for Credential
    /// </summary>
    public async Task UpdateDestinationCalendars(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(t => t.DestinationCalendars)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        var destinationCalendars = await _context
            .DestinationCalendars.Where(a =>
                destinationCalendarsId.Select(x => x.Id).Contains(a.Id)
            )
            .ToListAsync();

        if (destinationCalendars.Count == 0)
        {
            throw new NotFoundException();
        }

        credential.DestinationCalendars = destinationCalendars;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete one Credential
    /// </summary>
    public async Task DeleteCredential(CredentialWhereUniqueInput uniqueId)
    {
        var credential = await _context.Credentials.FindAsync(uniqueId.Id);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        _context.Credentials.Remove(credential);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Credentials
    /// </summary>
    public async Task<List<Credential>> Credentials(CredentialFindManyArgs findManyArgs)
    {
        var credentials = await _context
            .Credentials.Include(x => x.DestinationCalendars)
            .Include(x => x.User)
            .Include(x => x.AppField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return credentials.ConvertAll(credential => credential.ToDto());
    }

    /// <summary>
    /// Get one Credential
    /// </summary>
    public async Task<Credential> Credential(CredentialWhereUniqueInput uniqueId)
    {
        var credentials = await this.Credentials(
            new CredentialFindManyArgs { Where = new CredentialWhereInput { Id = uniqueId.Id } }
        );
        var credential = credentials.FirstOrDefault();
        if (credential == null)
        {
            throw new NotFoundException();
        }

        return credential;
    }

    /// <summary>
    /// Update one Credential
    /// </summary>
    public async Task UpdateCredential(
        CredentialWhereUniqueInput uniqueId,
        CredentialUpdateInput updateDto
    )
    {
        var credential = updateDto.ToModel(uniqueId);

        if (updateDto.DestinationCalendars != null)
        {
            credential.DestinationCalendars = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    updateDto.DestinationCalendars.Select(t => t).Contains(destinationCalendar.Id)
                )
                .ToListAsync();
        }

        _context.Entry(credential).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Credentials.Any(e => e.Id == credential.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
