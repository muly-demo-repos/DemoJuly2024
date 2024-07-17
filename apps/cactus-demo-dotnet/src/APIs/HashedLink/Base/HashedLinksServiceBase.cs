using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class HashedLinksServiceBase : IHashedLinksService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public HashedLinksServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Hashed Link
    /// </summary>
    public async Task<HashedLink> CreateHashedLink(HashedLinkCreateInput createDto)
    {
        var hashedLink = new HashedLinkDbModel { Link = createDto.Link };

        if (createDto.Id != null)
        {
            hashedLink.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            hashedLink.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        _context.HashedLinks.Add(hashedLink);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<HashedLinkDbModel>(hashedLink.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Hashed Link
    /// </summary>
    public async Task DeleteHashedLink(HashedLinkWhereUniqueInput uniqueId)
    {
        var hashedLink = await _context.HashedLinks.FindAsync(uniqueId.Id);
        if (hashedLink == null)
        {
            throw new NotFoundException();
        }

        _context.HashedLinks.Remove(hashedLink);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many HashedLinks
    /// </summary>
    public async Task<List<HashedLink>> HashedLinks(HashedLinkFindManyArgs findManyArgs)
    {
        var hashedLinks = await _context
            .HashedLinks.Include(x => x.EventType)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return hashedLinks.ConvertAll(hashedLink => hashedLink.ToDto());
    }

    /// <summary>
    /// Get one Hashed Link
    /// </summary>
    public async Task<HashedLink> HashedLink(HashedLinkWhereUniqueInput uniqueId)
    {
        var hashedLinks = await this.HashedLinks(
            new HashedLinkFindManyArgs { Where = new HashedLinkWhereInput { Id = uniqueId.Id } }
        );
        var hashedLink = hashedLinks.FirstOrDefault();
        if (hashedLink == null)
        {
            throw new NotFoundException();
        }

        return hashedLink;
    }

    /// <summary>
    /// Get a Event Type record for Hashed Link
    /// </summary>
    public async Task<EventType> GetEventType(HashedLinkWhereUniqueInput uniqueId)
    {
        var hashedLink = await _context
            .HashedLinks.Where(hashedLink => hashedLink.Id == uniqueId.Id)
            .Include(hashedLink => hashedLink.EventType)
            .FirstOrDefaultAsync();
        if (hashedLink == null)
        {
            throw new NotFoundException();
        }
        return hashedLink.EventType.ToDto();
    }

    /// <summary>
    /// Meta data about Hashed Link records
    /// </summary>
    public async Task<MetadataDto> HashedLinksMeta(HashedLinkFindManyArgs findManyArgs)
    {
        var count = await _context.HashedLinks.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Hashed Link
    /// </summary>
    public async Task UpdateHashedLink(
        HashedLinkWhereUniqueInput uniqueId,
        HashedLinkUpdateInput updateDto
    )
    {
        var hashedLink = updateDto.ToModel(uniqueId);

        _context.Entry(hashedLink).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.HashedLinks.Any(e => e.Id == hashedLink.Id))
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
