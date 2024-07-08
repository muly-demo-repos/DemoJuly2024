using Microsoft.EntityFrameworkCore;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;
using QaService.APIs.Extensions;
using QaService.Infrastructure;
using QaService.Infrastructure.Models;

namespace QaService.APIs;

public abstract class TicketCriteriaServiceBase : ITicketCriteriaService
{
    protected readonly QaServiceDbContext _context;

    public TicketCriteriaServiceBase(QaServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TicketCriteria
    /// </summary>
    public async Task<TicketCriterion> CreateTicketCriterion(TicketCriterionCreateInput createDto)
    {
        var ticketCriterion = new TicketCriterionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Criteria = createDto.Criteria
        };

        if (createDto.Id != null)
        {
            ticketCriterion.Id = createDto.Id;
        }
        if (createDto.TicketCategory != null)
        {
            ticketCriterion.TicketCategory = await _context
                .TicketCategories.Where(ticketCategory =>
                    createDto.TicketCategory.Id == ticketCategory.Id
                )
                .FirstOrDefaultAsync();
        }

        _context.TicketCriteria.Add(ticketCriterion);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TicketCriterionDbModel>(ticketCriterion.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TicketCriteria
    /// </summary>
    public async Task DeleteTicketCriterion(TicketCriterionWhereUniqueInput uniqueId)
    {
        var ticketCriterion = await _context.TicketCriteria.FindAsync(uniqueId.Id);
        if (ticketCriterion == null)
        {
            throw new NotFoundException();
        }

        _context.TicketCriteria.Remove(ticketCriterion);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TicketCriteria
    /// </summary>
    public async Task<List<TicketCriterion>> TicketCriteria(
        TicketCriterionFindManyArgs findManyArgs
    )
    {
        var ticketCriteria = await _context
            .TicketCriteria.Include(x => x.TicketCategory)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return ticketCriteria.ConvertAll(ticketCriterion => ticketCriterion.ToDto());
    }

    /// <summary>
    /// Get one TicketCriteria
    /// </summary>
    public async Task<TicketCriterion> TicketCriterion(TicketCriterionWhereUniqueInput uniqueId)
    {
        var ticketCriteria = await this.TicketCriteria(
            new TicketCriterionFindManyArgs
            {
                Where = new TicketCriterionWhereInput { Id = uniqueId.Id }
            }
        );
        var ticketCriterion = ticketCriteria.FirstOrDefault();
        if (ticketCriterion == null)
        {
            throw new NotFoundException();
        }

        return ticketCriterion;
    }

    /// <summary>
    /// Get a Ticket Category record for TicketCriteria
    /// </summary>
    public async Task<TicketCategory> GetTicketCategory(TicketCriterionWhereUniqueInput uniqueId)
    {
        var ticketCriterion = await _context
            .TicketCriteria.Where(ticketCriterion => ticketCriterion.Id == uniqueId.Id)
            .Include(ticketCriterion => ticketCriterion.TicketCategory)
            .FirstOrDefaultAsync();
        if (ticketCriterion == null)
        {
            throw new NotFoundException();
        }
        return ticketCriterion.TicketCategory.ToDto();
    }

    /// <summary>
    /// Meta data about TicketCriteria records
    /// </summary>
    public async Task<MetadataDto> TicketCriteriaMeta(TicketCriterionFindManyArgs findManyArgs)
    {
        var count = await _context.TicketCriteria.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one TicketCriteria
    /// </summary>
    public async Task UpdateTicketCriterion(
        TicketCriterionWhereUniqueInput uniqueId,
        TicketCriterionUpdateInput updateDto
    )
    {
        var ticketCriterion = updateDto.ToModel(uniqueId);

        _context.Entry(ticketCriterion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TicketCriteria.Any(e => e.Id == ticketCriterion.Id))
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
