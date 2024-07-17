using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class TeamsServiceBase : ITeamsService
{
    protected readonly CactusDemoDbContext _context;

    public TeamsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Team
    /// </summary>
    public async Task<Team> CreateTeam(TeamCreateInput createDto)
    {
        var team = new TeamDbModel
        {
            Name = createDto.Name,
            Slug = createDto.Slug,
            Logo = createDto.Logo,
            Bio = createDto.Bio,
            HideBranding = createDto.HideBranding
        };

        if (createDto.Id != null)
        {
            team.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            team.EventType = await _context
                .EventTypes.Where(eventType =>
                    createDto.EventType.Select(t => t.Id).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Membership != null)
        {
            team.Membership = await _context
                .Memberships.Where(membership =>
                    createDto.Membership.Select(t => t.Id).Contains(membership.Id)
                )
                .ToListAsync();
        }

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TeamDbModel>(team.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Team
    /// </summary>
    public async Task DeleteTeam(TeamWhereUniqueInput uniqueId)
    {
        var team = await _context.Teams.FindAsync(uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Teams
    /// </summary>
    public async Task<List<Team>> Teams(TeamFindManyArgs findManyArgs)
    {
        var teams = await _context
            .Teams.Include(x => x.EventType)
            .Include(x => x.Membership)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return teams.ConvertAll(team => team.ToDto());
    }

    /// <summary>
    /// Get one Team
    /// </summary>
    public async Task<Team> Team(TeamWhereUniqueInput uniqueId)
    {
        var teams = await this.Teams(
            new TeamFindManyArgs { Where = new TeamWhereInput { Id = uniqueId.Id } }
        );
        var team = teams.FirstOrDefault();
        if (team == null)
        {
            throw new NotFoundException();
        }

        return team;
    }

    /// <summary>
    /// Connect multiple Event Type records to Team
    /// </summary>
    public async Task ConnectEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        var eventTypesToConnect = eventTypes.Except(team.EventType);

        foreach (var eventType in eventTypesToConnect)
        {
            team.EventType.Add(eventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Membership records to Team
    /// </summary>
    public async Task ConnectMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(t => membershipsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (memberships.Count == 0)
        {
            throw new NotFoundException();
        }

        var membershipsToConnect = memberships.Except(team.Membership);

        foreach (var membership in membershipsToConnect)
        {
            team.Membership.Add(membership);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Type records from Team
    /// </summary>
    public async Task DisconnectEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(x => x.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(t => eventTypesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var eventType in eventTypes)
        {
            team.EventType?.Remove(eventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Membership records from Team
    /// </summary>
    public async Task DisconnectMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(x => x.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(t => membershipsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var membership in memberships)
        {
            team.Membership?.Remove(membership);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Event Type records for Team
    /// </summary>
    public async Task<List<EventType>> FindEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeFindManyArgs teamFindManyArgs
    )
    {
        var eventTypes = await _context
            .EventTypes.Where(m => m.TeamId == uniqueId.Id)
            .ApplyWhere(teamFindManyArgs.Where)
            .ApplySkip(teamFindManyArgs.Skip)
            .ApplyTake(teamFindManyArgs.Take)
            .ApplyOrderBy(teamFindManyArgs.SortBy)
            .ToListAsync();

        return eventTypes.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Membership records for Team
    /// </summary>
    public async Task<List<Membership>> FindMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipFindManyArgs teamFindManyArgs
    )
    {
        var memberships = await _context
            .Memberships.Where(m => m.TeamId == uniqueId.Id)
            .ApplyWhere(teamFindManyArgs.Where)
            .ApplySkip(teamFindManyArgs.Skip)
            .ApplyTake(teamFindManyArgs.Take)
            .ApplyOrderBy(teamFindManyArgs.SortBy)
            .ToListAsync();

        return memberships.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    public async Task<MetadataDto> TeamsMeta(TeamFindManyArgs findManyArgs)
    {
        var count = await _context.Teams.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Event Type records for Team
    /// </summary>
    public async Task UpdateEventType(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(t => t.EventType)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var eventTypes = await _context
            .EventTypes.Where(a => eventTypesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (eventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        team.EventType = eventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Membership records for Team
    /// </summary>
    public async Task UpdateMembership(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(t => t.Membership)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        var memberships = await _context
            .Memberships.Where(a => membershipsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (memberships.Count == 0)
        {
            throw new NotFoundException();
        }

        team.Membership = memberships;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    public async Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto)
    {
        var team = updateDto.ToModel(uniqueId);

        if (updateDto.EventType != null)
        {
            team.EventType = await _context
                .EventTypes.Where(eventType =>
                    updateDto.EventType.Select(t => t).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Membership != null)
        {
            team.Membership = await _context
                .Memberships.Where(membership =>
                    updateDto.Membership.Select(t => t).Contains(membership.Id)
                )
                .ToListAsync();
        }

        _context.Entry(team).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Teams.Any(e => e.Id == team.Id))
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
