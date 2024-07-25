using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class CredentialsServiceBase : ICredentialsService
{
    protected readonly CactusDemoDbContext _context;

    public CredentialsServiceBase(CactusDemoDbContext context)
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
        if (createDto.AppField != null)
        {
            credential.AppField = await _context
                .AppModels.Where(appModel => createDto.AppField.Id == appModel.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.DestinationCalendar != null)
        {
            credential.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto.DestinationCalendar.Select(t => t.Id).Contains(destinationCalendar.Id)
                )
                .ToListAsync();
        }

        if (createDto.Users != null)
        {
            credential.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
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
    /// Connect multiple Destination Calendar records to Credential
    /// </summary>
    public async Task ConnectDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(x => x.DestinationCalendar)
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
            credential.DestinationCalendar
        );

        foreach (var destinationCalendar in destinationCalendarsToConnect)
        {
            credential.DestinationCalendar.Add(destinationCalendar);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Destination Calendar records from Credential
    /// </summary>
    public async Task DisconnectDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(x => x.DestinationCalendar)
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
            credential.DestinationCalendar?.Remove(destinationCalendar);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Destination Calendar records for Credential
    /// </summary>
    public async Task<List<DestinationCalendar>> FindDestinationCalendar(
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
    /// Get a Users record for Credential
    /// </summary>
    public async Task<User> GetUsers(CredentialWhereUniqueInput uniqueId)
    {
        var credential = await _context
            .Credentials.Where(credential => credential.Id == uniqueId.Id)
            .Include(credential => credential.Users)
            .FirstOrDefaultAsync();
        if (credential == null)
        {
            throw new NotFoundException();
        }
        return credential.Users.ToDto();
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
    /// Update multiple Destination Calendar records for Credential
    /// </summary>
    public async Task UpdateDestinationCalendar(
        CredentialWhereUniqueInput uniqueId,
        DestinationCalendarWhereUniqueInput[] destinationCalendarsId
    )
    {
        var credential = await _context
            .Credentials.Include(t => t.DestinationCalendar)
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

        credential.DestinationCalendar = destinationCalendars;
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
            .Credentials.Include(x => x.AppField)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.Users)
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

        if (updateDto.DestinationCalendar != null)
        {
            credential.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    updateDto.DestinationCalendar.Select(t => t).Contains(destinationCalendar.Id)
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
