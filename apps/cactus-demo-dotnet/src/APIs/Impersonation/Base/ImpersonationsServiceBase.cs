using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class ImpersonationsServiceBase : IImpersonationsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public ImpersonationsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Impersonation
    /// </summary>
    public async Task<Impersonation> CreateImpersonation(ImpersonationCreateInput createDto)
    {
        var impersonation = new ImpersonationDbModel { CreatedAt = createDto.CreatedAt };

        if (createDto.Id != null)
        {
            impersonation.Id = createDto.Id.Value;
        }
        if (createDto.ImpersonatedUser != null)
        {
            impersonation.ImpersonatedUser = await _context
                .Users.Where(user => createDto.ImpersonatedUser.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Impersonations.Add(impersonation);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ImpersonationDbModel>(impersonation.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Impersonation
    /// </summary>
    public async Task DeleteImpersonation(ImpersonationWhereUniqueInput uniqueId)
    {
        var impersonation = await _context.Impersonations.FindAsync(uniqueId.Id);
        if (impersonation == null)
        {
            throw new NotFoundException();
        }

        _context.Impersonations.Remove(impersonation);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Impersonations
    /// </summary>
    public async Task<List<Impersonation>> Impersonations(ImpersonationFindManyArgs findManyArgs)
    {
        var impersonations = await _context
            .Impersonations.Include(x => x.ImpersonatedUser)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return impersonations.ConvertAll(impersonation => impersonation.ToDto());
    }

    /// <summary>
    /// Get one Impersonation
    /// </summary>
    public async Task<Impersonation> Impersonation(ImpersonationWhereUniqueInput uniqueId)
    {
        var impersonations = await this.Impersonations(
            new ImpersonationFindManyArgs
            {
                Where = new ImpersonationWhereInput { Id = uniqueId.Id }
            }
        );
        var impersonation = impersonations.FirstOrDefault();
        if (impersonation == null)
        {
            throw new NotFoundException();
        }

        return impersonation;
    }

    /// <summary>
    /// Get a Impersonated By record for Impersonation
    /// </summary>
    public async Task<User> GetImpersonatedBy(ImpersonationWhereUniqueInput uniqueId)
    {
        var impersonation = await _context
            .Impersonations.Where(impersonation => impersonation.Id == uniqueId.Id)
            .Include(impersonation => impersonation.ImpersonatedUser)
            .FirstOrDefaultAsync();
        if (impersonation == null)
        {
            throw new NotFoundException();
        }
        return impersonation.ImpersonatedUser.ToDto();
    }

    /// <summary>
    /// Get a Impersonated User record for Impersonation
    /// </summary>
    public async Task<User> GetImpersonatedUser(ImpersonationWhereUniqueInput uniqueId)
    {
        var impersonation = await _context
            .Impersonations.Where(impersonation => impersonation.Id == uniqueId.Id)
            .Include(impersonation => impersonation.ImpersonatedUser)
            .FirstOrDefaultAsync();
        if (impersonation == null)
        {
            throw new NotFoundException();
        }
        return impersonation.ImpersonatedUser.ToDto();
    }

    /// <summary>
    /// Meta data about Impersonation records
    /// </summary>
    public async Task<MetadataDto> ImpersonationsMeta(ImpersonationFindManyArgs findManyArgs)
    {
        var count = await _context.Impersonations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Impersonation
    /// </summary>
    public async Task UpdateImpersonation(
        ImpersonationWhereUniqueInput uniqueId,
        ImpersonationUpdateInput updateDto
    )
    {
        var impersonation = updateDto.ToModel(uniqueId);

        _context.Entry(impersonation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Impersonations.Any(e => e.Id == impersonation.Id))
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
