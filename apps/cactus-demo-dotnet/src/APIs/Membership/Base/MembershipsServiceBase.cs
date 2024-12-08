using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class MembershipsServiceBase : IMembershipsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public MembershipsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Membership
    /// </summary>
    public async Task<Membership> CreateMembership(MembershipCreateInput createDto)
    {
        var membership = new MembershipDbModel
        {
            Accepted = createDto.Accepted,
            Role = createDto.Role
        };

        if (createDto.Id != null)
        {
            membership.Id = createDto.Id.Value;
        }
        if (createDto.User != null)
        {
            membership.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Team != null)
        {
            membership.Team = await _context
                .Teams.Where(team => createDto.Team.Id == team.Id)
                .FirstOrDefaultAsync();
        }

        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MembershipDbModel>(membership.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Membership
    /// </summary>
    public async Task DeleteMembership(MembershipWhereUniqueInput uniqueId)
    {
        var membership = await _context.Memberships.FindAsync(uniqueId.Id);
        if (membership == null)
        {
            throw new NotFoundException();
        }

        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Memberships
    /// </summary>
    public async Task<List<Membership>> Memberships(MembershipFindManyArgs findManyArgs)
    {
        var memberships = await _context
            .Memberships.Include(x => x.User)
            .Include(x => x.Team)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return memberships.ConvertAll(membership => membership.ToDto());
    }

    /// <summary>
    /// Get one Membership
    /// </summary>
    public async Task<Membership> Membership(MembershipWhereUniqueInput uniqueId)
    {
        var memberships = await this.Memberships(
            new MembershipFindManyArgs { Where = new MembershipWhereInput { Id = uniqueId.Id } }
        );
        var membership = memberships.FirstOrDefault();
        if (membership == null)
        {
            throw new NotFoundException();
        }

        return membership;
    }

    /// <summary>
    /// Get a Team record for Membership
    /// </summary>
    public async Task<Team> GetTeam(MembershipWhereUniqueInput uniqueId)
    {
        var membership = await _context
            .Memberships.Where(membership => membership.Id == uniqueId.Id)
            .Include(membership => membership.Team)
            .FirstOrDefaultAsync();
        if (membership == null)
        {
            throw new NotFoundException();
        }
        return membership.Team.ToDto();
    }

    /// <summary>
    /// Get a User record for Membership
    /// </summary>
    public async Task<User> GetUser(MembershipWhereUniqueInput uniqueId)
    {
        var membership = await _context
            .Memberships.Where(membership => membership.Id == uniqueId.Id)
            .Include(membership => membership.User)
            .FirstOrDefaultAsync();
        if (membership == null)
        {
            throw new NotFoundException();
        }
        return membership.User.ToDto();
    }

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    public async Task<MetadataDto> MembershipsMeta(MembershipFindManyArgs findManyArgs)
    {
        var count = await _context.Memberships.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Membership
    /// </summary>
    public async Task UpdateMembership(
        MembershipWhereUniqueInput uniqueId,
        MembershipUpdateInput updateDto
    )
    {
        var membership = updateDto.ToModel(uniqueId);

        _context.Entry(membership).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Memberships.Any(e => e.Id == membership.Id))
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
