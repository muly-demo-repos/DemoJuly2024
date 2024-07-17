using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class TeamsServiceBase : ITeamsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public TeamsServiceBase(CactusDemoDotnetDbContext context)
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
        if (createDto.EventTypes != null)
        {
            team.EventTypes = await _context
                .EventTypes.Where(eventType =>
                    createDto.EventTypes.Select(t => t.Id).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Members != null)
        {
            team.Members = await _context
                .Memberships.Where(membership =>
                    createDto.Members.Select(t => t.Id).Contains(membership.Id)
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
            .Teams.Include(x => x.EventTypes)
            .Include(x => x.Members)
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
    /// Connect multiple Event Types records to Team
    /// </summary>
    public async Task ConnectEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(x => x.EventTypes)
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

        var eventTypesToConnect = eventTypes.Except(team.EventTypes);

        foreach (var eventType in eventTypesToConnect)
        {
            team.EventTypes.Add(eventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Members records to Team
    /// </summary>
    public async Task ConnectMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(x => x.Members)
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

        var membershipsToConnect = memberships.Except(team.Members);

        foreach (var membership in membershipsToConnect)
        {
            team.Members.Add(membership);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Event Types records from Team
    /// </summary>
    public async Task DisconnectEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(x => x.EventTypes)
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
            team.EventTypes?.Remove(eventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Members records from Team
    /// </summary>
    public async Task DisconnectMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(x => x.Members)
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
            team.Members?.Remove(membership);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Event Types records for Team
    /// </summary>
    public async Task<List<EventType>> FindEventTypes(
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
    /// Find multiple Members records for Team
    /// </summary>
    public async Task<List<Membership>> FindMembers(
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
    /// Update multiple Event Types records for Team
    /// </summary>
    public async Task UpdateEventTypes(
        TeamWhereUniqueInput uniqueId,
        EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        var team = await _context
            .Teams.Include(t => t.EventTypes)
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

        team.EventTypes = eventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Members records for Team
    /// </summary>
    public async Task UpdateMembers(
        TeamWhereUniqueInput uniqueId,
        MembershipWhereUniqueInput[] membershipsId
    )
    {
        var team = await _context
            .Teams.Include(t => t.Members)
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

        team.Members = memberships;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    public async Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto)
    {
        var team = updateDto.ToModel(uniqueId);

        if (updateDto.EventTypes != null)
        {
            team.EventTypes = await _context
                .EventTypes.Where(eventType =>
                    updateDto.EventTypes.Select(t => t).Contains(eventType.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Members != null)
        {
            team.Members = await _context
                .Memberships.Where(membership =>
                    updateDto.Members.Select(t => t).Contains(membership.Id)
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
