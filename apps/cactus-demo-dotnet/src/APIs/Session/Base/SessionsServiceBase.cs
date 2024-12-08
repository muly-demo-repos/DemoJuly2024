using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class SessionsServiceBase : ISessionsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public SessionsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Session
    /// </summary>
    public async Task<Session> CreateSession(SessionCreateInput createDto)
    {
        var session = new SessionDbModel
        {
            SessionToken = createDto.SessionToken,
            Expires = createDto.Expires
        };

        if (createDto.Id != null)
        {
            session.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            session.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SessionDbModel>(session.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Session
    /// </summary>
    public async Task DeleteSession(SessionWhereUniqueInput uniqueId)
    {
        var session = await _context.Sessions.FindAsync(uniqueId.Id);
        if (session == null)
        {
            throw new NotFoundException();
        }

        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Sessions
    /// </summary>
    public async Task<List<Session>> Sessions(SessionFindManyArgs findManyArgs)
    {
        var sessions = await _context
            .Sessions.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return sessions.ConvertAll(session => session.ToDto());
    }

    /// <summary>
    /// Get one Session
    /// </summary>
    public async Task<Session> Session(SessionWhereUniqueInput uniqueId)
    {
        var sessions = await this.Sessions(
            new SessionFindManyArgs { Where = new SessionWhereInput { Id = uniqueId.Id } }
        );
        var session = sessions.FirstOrDefault();
        if (session == null)
        {
            throw new NotFoundException();
        }

        return session;
    }

    /// <summary>
    /// Get a User record for Session
    /// </summary>
    public async Task<User> GetUser(SessionWhereUniqueInput uniqueId)
    {
        var session = await _context
            .Sessions.Where(session => session.Id == uniqueId.Id)
            .Include(session => session.User)
            .FirstOrDefaultAsync();
        if (session == null)
        {
            throw new NotFoundException();
        }
        return session.User.ToDto();
    }

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    public async Task<MetadataDto> SessionsMeta(SessionFindManyArgs findManyArgs)
    {
        var count = await _context.Sessions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Session
    /// </summary>
    public async Task UpdateSession(SessionWhereUniqueInput uniqueId, SessionUpdateInput updateDto)
    {
        var session = updateDto.ToModel(uniqueId);

        _context.Entry(session).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sessions.Any(e => e.Id == session.Id))
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
