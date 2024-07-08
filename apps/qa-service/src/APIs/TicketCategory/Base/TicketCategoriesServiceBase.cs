using Microsoft.EntityFrameworkCore;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;
using QaService.APIs.Extensions;
using QaService.Infrastructure;
using QaService.Infrastructure.Models;

namespace QaService.APIs;

public abstract class TicketCategoriesServiceBase : ITicketCategoriesService
{
    protected readonly QaServiceDbContext _context;

    public TicketCategoriesServiceBase(QaServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TicketCategory
    /// </summary>
    public async Task<TicketCategory> CreateTicketCategory(TicketCategoryCreateInput createDto)
    {
        var ticketCategory = new TicketCategoryDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            CategoryName = createDto.CategoryName
        };

        if (createDto.Id != null)
        {
            ticketCategory.Id = createDto.Id;
        }
        if (createDto.TicketCriteria != null)
        {
            ticketCategory.TicketCriteria = await _context
                .TicketCriteria.Where(ticketCriterion =>
                    createDto.TicketCriteria.Select(t => t.Id).Contains(ticketCriterion.Id)
                )
                .ToListAsync();
        }

        _context.TicketCategories.Add(ticketCategory);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TicketCategoryDbModel>(ticketCategory.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TicketCategory
    /// </summary>
    public async Task DeleteTicketCategory(TicketCategoryWhereUniqueInput uniqueId)
    {
        var ticketCategory = await _context.TicketCategories.FindAsync(uniqueId.Id);
        if (ticketCategory == null)
        {
            throw new NotFoundException();
        }

        _context.TicketCategories.Remove(ticketCategory);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TicketCategories
    /// </summary>
    public async Task<List<TicketCategory>> TicketCategories(
        TicketCategoryFindManyArgs findManyArgs
    )
    {
        var ticketCategories = await _context
            .TicketCategories.Include(x => x.TicketCriteria)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return ticketCategories.ConvertAll(ticketCategory => ticketCategory.ToDto());
    }

    /// <summary>
    /// Get one TicketCategory
    /// </summary>
    public async Task<TicketCategory> TicketCategory(TicketCategoryWhereUniqueInput uniqueId)
    {
        var ticketCategories = await this.TicketCategories(
            new TicketCategoryFindManyArgs
            {
                Where = new TicketCategoryWhereInput { Id = uniqueId.Id }
            }
        );
        var ticketCategory = ticketCategories.FirstOrDefault();
        if (ticketCategory == null)
        {
            throw new NotFoundException();
        }

        return ticketCategory;
    }

    /// <summary>
    /// Meta data about TicketCategory records
    /// </summary>
    public async Task<MetadataDto> TicketCategoriesMeta(TicketCategoryFindManyArgs findManyArgs)
    {
        var count = await _context.TicketCategories.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Connect multiple TicketCriteria records to TicketCategory
    /// </summary>
    public async Task ConnectTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        var ticketCategory = await _context
            .TicketCategories.Include(x => x.TicketCriteria)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (ticketCategory == null)
        {
            throw new NotFoundException();
        }

        var ticketCriteria = await _context
            .TicketCriteria.Where(t => ticketCriteriaId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (ticketCriteria.Count == 0)
        {
            throw new NotFoundException();
        }

        var ticketCriteriaToConnect = ticketCriteria.Except(ticketCategory.TicketCriteria);

        foreach (var ticketCriterion in ticketCriteriaToConnect)
        {
            ticketCategory.TicketCriteria.Add(ticketCriterion);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple TicketCriteria records from TicketCategory
    /// </summary>
    public async Task DisconnectTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        var ticketCategory = await _context
            .TicketCategories.Include(x => x.TicketCriteria)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (ticketCategory == null)
        {
            throw new NotFoundException();
        }

        var ticketCriteria = await _context
            .TicketCriteria.Where(t => ticketCriteriaId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var ticketCriterion in ticketCriteria)
        {
            ticketCategory.TicketCriteria?.Remove(ticketCriterion);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple TicketCriteria records for TicketCategory
    /// </summary>
    public async Task<List<TicketCriterion>> FindTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionFindManyArgs ticketCategoryFindManyArgs
    )
    {
        var ticketCriteria = await _context
            .TicketCriteria.Where(m => m.TicketCategoryId == uniqueId.Id)
            .ApplyWhere(ticketCategoryFindManyArgs.Where)
            .ApplySkip(ticketCategoryFindManyArgs.Skip)
            .ApplyTake(ticketCategoryFindManyArgs.Take)
            .ApplyOrderBy(ticketCategoryFindManyArgs.SortBy)
            .ToListAsync();

        return ticketCriteria.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple TicketCriteria records for TicketCategory
    /// </summary>
    public async Task UpdateTicketCriteria(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCriterionWhereUniqueInput[] ticketCriteriaId
    )
    {
        var ticketCategory = await _context
            .TicketCategories.Include(t => t.TicketCriteria)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (ticketCategory == null)
        {
            throw new NotFoundException();
        }

        var ticketCriteria = await _context
            .TicketCriteria.Where(a => ticketCriteriaId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (ticketCriteria.Count == 0)
        {
            throw new NotFoundException();
        }

        ticketCategory.TicketCriteria = ticketCriteria;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one TicketCategory
    /// </summary>
    public async Task UpdateTicketCategory(
        TicketCategoryWhereUniqueInput uniqueId,
        TicketCategoryUpdateInput updateDto
    )
    {
        var ticketCategory = updateDto.ToModel(uniqueId);

        if (updateDto.TicketCriteria != null)
        {
            ticketCategory.TicketCriteria = await _context
                .TicketCriteria.Where(ticketCriterion =>
                    updateDto.TicketCriteria.Select(t => t).Contains(ticketCriterion.Id)
                )
                .ToListAsync();
        }

        _context.Entry(ticketCategory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TicketCategories.Any(e => e.Id == ticketCategory.Id))
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
