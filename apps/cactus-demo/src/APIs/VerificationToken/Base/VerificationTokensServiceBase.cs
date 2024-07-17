using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class VerificationTokensServiceBase : IVerificationTokensService
{
    protected readonly CactusDemoDbContext _context;

    public VerificationTokensServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Verification Token
    /// </summary>
    public async Task<VerificationToken> CreateVerificationToken(
        VerificationTokenCreateInput createDto
    )
    {
        var verificationToken = new VerificationTokenDbModel
        {
            Identifier = createDto.Identifier,
            Token = createDto.Token,
            Expires = createDto.Expires,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            verificationToken.Id = createDto.Id.Value;
        }

        _context.VerificationTokens.Add(verificationToken);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VerificationTokenDbModel>(verificationToken.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Verification Token
    /// </summary>
    public async Task DeleteVerificationToken(VerificationTokenWhereUniqueInput uniqueId)
    {
        var verificationToken = await _context.VerificationTokens.FindAsync(uniqueId.Id);
        if (verificationToken == null)
        {
            throw new NotFoundException();
        }

        _context.VerificationTokens.Remove(verificationToken);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VerificationTokens
    /// </summary>
    public async Task<List<VerificationToken>> VerificationTokens(
        VerificationTokenFindManyArgs findManyArgs
    )
    {
        var verificationTokens = await _context
            .VerificationTokens.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return verificationTokens.ConvertAll(verificationToken => verificationToken.ToDto());
    }

    /// <summary>
    /// Get one Verification Token
    /// </summary>
    public async Task<VerificationToken> VerificationToken(
        VerificationTokenWhereUniqueInput uniqueId
    )
    {
        var verificationTokens = await this.VerificationTokens(
            new VerificationTokenFindManyArgs
            {
                Where = new VerificationTokenWhereInput { Id = uniqueId.Id }
            }
        );
        var verificationToken = verificationTokens.FirstOrDefault();
        if (verificationToken == null)
        {
            throw new NotFoundException();
        }

        return verificationToken;
    }

    /// <summary>
    /// Update one Verification Token
    /// </summary>
    public async Task UpdateVerificationToken(
        VerificationTokenWhereUniqueInput uniqueId,
        VerificationTokenUpdateInput updateDto
    )
    {
        var verificationToken = updateDto.ToModel(uniqueId);

        _context.Entry(verificationToken).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VerificationTokens.Any(e => e.Id == verificationToken.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Meta data about Verification Token records
    /// </summary>
    public async Task<MetadataDto> VerificationTokensMeta(
        VerificationTokenFindManyArgs findManyArgs
    )
    {
        var count = await _context.VerificationTokens.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }
}
