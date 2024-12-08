using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class ResetPasswordRequestsServiceBase : IResetPasswordRequestsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public ResetPasswordRequestsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Reset Password Request
    /// </summary>
    public async Task<ResetPasswordRequest> CreateResetPasswordRequest(
        ResetPasswordRequestCreateInput createDto
    )
    {
        var resetPasswordRequest = new ResetPasswordRequestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Email = createDto.Email,
            Expires = createDto.Expires
        };

        if (createDto.Id != null)
        {
            resetPasswordRequest.Id = createDto.Id;
        }

        _context.ResetPasswordRequests.Add(resetPasswordRequest);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ResetPasswordRequestDbModel>(resetPasswordRequest.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Reset Password Request
    /// </summary>
    public async Task DeleteResetPasswordRequest(ResetPasswordRequestWhereUniqueInput uniqueId)
    {
        var resetPasswordRequest = await _context.ResetPasswordRequests.FindAsync(uniqueId.Id);
        if (resetPasswordRequest == null)
        {
            throw new NotFoundException();
        }

        _context.ResetPasswordRequests.Remove(resetPasswordRequest);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ResetPasswordRequests
    /// </summary>
    public async Task<List<ResetPasswordRequest>> ResetPasswordRequests(
        ResetPasswordRequestFindManyArgs findManyArgs
    )
    {
        var resetPasswordRequests = await _context
            .ResetPasswordRequests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return resetPasswordRequests.ConvertAll(resetPasswordRequest =>
            resetPasswordRequest.ToDto()
        );
    }

    /// <summary>
    /// Get one Reset Password Request
    /// </summary>
    public async Task<ResetPasswordRequest> ResetPasswordRequest(
        ResetPasswordRequestWhereUniqueInput uniqueId
    )
    {
        var resetPasswordRequests = await this.ResetPasswordRequests(
            new ResetPasswordRequestFindManyArgs
            {
                Where = new ResetPasswordRequestWhereInput { Id = uniqueId.Id }
            }
        );
        var resetPasswordRequest = resetPasswordRequests.FirstOrDefault();
        if (resetPasswordRequest == null)
        {
            throw new NotFoundException();
        }

        return resetPasswordRequest;
    }

    /// <summary>
    /// Meta data about Reset Password Request records
    /// </summary>
    public async Task<MetadataDto> ResetPasswordRequestsMeta(
        ResetPasswordRequestFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .ResetPasswordRequests.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Reset Password Request
    /// </summary>
    public async Task UpdateResetPasswordRequest(
        ResetPasswordRequestWhereUniqueInput uniqueId,
        ResetPasswordRequestUpdateInput updateDto
    )
    {
        var resetPasswordRequest = updateDto.ToModel(uniqueId);

        _context.Entry(resetPasswordRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ResetPasswordRequests.Any(e => e.Id == resetPasswordRequest.Id))
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
