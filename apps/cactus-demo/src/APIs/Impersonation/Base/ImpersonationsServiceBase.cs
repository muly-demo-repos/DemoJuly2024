using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class ImpersonationsServiceBase : IImpersonationsService
{
    protected readonly CactusDemoDbContext _context;

    public ImpersonationsServiceBase(CactusDemoDbContext context)
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
        if (createDto.UsersImpersonationsImpersonatedByIdTousers != null)
        {
            impersonation.UsersImpersonationsImpersonatedByIdTousers = await _context
                .Users.Where(user =>
                    createDto.UsersImpersonationsImpersonatedByIdTousers.Id == user.Id
                )
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
            .Impersonations.Include(x => x.UsersImpersonationsImpersonatedByIdTousers)
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
    /// Get a Users Impersonations Impersonated By Id Tousers record for Impersonation
    /// </summary>
    public async Task<User> GetUsersImpersonationsImpersonatedByIdTousers(
        ImpersonationWhereUniqueInput uniqueId
    )
    {
        var impersonation = await _context
            .Impersonations.Where(impersonation => impersonation.Id == uniqueId.Id)
            .Include(impersonation => impersonation.UsersImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync();
        if (impersonation == null)
        {
            throw new NotFoundException();
        }
        return impersonation.UsersImpersonationsImpersonatedByIdTousers.ToDto();
    }

    /// <summary>
    /// Get a Users Impersonations Impersonated User Id Tousers record for Impersonation
    /// </summary>
    public async Task<User> GetUsersImpersonationsImpersonatedUserIdTousers(
        ImpersonationWhereUniqueInput uniqueId
    )
    {
        var impersonation = await _context
            .Impersonations.Where(impersonation => impersonation.Id == uniqueId.Id)
            .Include(impersonation => impersonation.UsersImpersonationsImpersonatedByIdTousers)
            .FirstOrDefaultAsync();
        if (impersonation == null)
        {
            throw new NotFoundException();
        }
        return impersonation.UsersImpersonationsImpersonatedByIdTousers.ToDto();
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
