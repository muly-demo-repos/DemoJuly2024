using Microsoft.EntityFrameworkCore;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;
using QaService.APIs.Extensions;
using QaService.Infrastructure;
using QaService.Infrastructure.Models;

namespace QaService.APIs;

public abstract class ProcessingAuditsServiceBase : IProcessingAuditsService
{
    protected readonly QaServiceDbContext _context;

    public ProcessingAuditsServiceBase(QaServiceDbContext context)
    {
        _context = context;
    }

    public async Task<double> CalculateSomething(string data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create one ProcessingAudit
    /// </summary>
    public async Task<ProcessingAudit> CreateProcessingAudit(ProcessingAuditCreateInput createDto)
    {
        var processingAudit = new ProcessingAuditDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            TicketNumber = createDto.TicketNumber,
            TypeField = createDto.TypeField,
            Subtype = createDto.Subtype,
            Item = createDto.Item,
            Criteria = createDto.Criteria,
            Result = createDto.Result
        };

        if (createDto.Id != null)
        {
            processingAudit.Id = createDto.Id;
        }

        _context.ProcessingAudits.Add(processingAudit);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ProcessingAuditDbModel>(processingAudit.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ProcessingAudit
    /// </summary>
    public async Task DeleteProcessingAudit(ProcessingAuditWhereUniqueInput uniqueId)
    {
        var processingAudit = await _context.ProcessingAudits.FindAsync(uniqueId.Id);
        if (processingAudit == null)
        {
            throw new NotFoundException();
        }

        _context.ProcessingAudits.Remove(processingAudit);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ProcessingAudits
    /// </summary>
    public async Task<List<ProcessingAudit>> ProcessingAudits(
        ProcessingAuditFindManyArgs findManyArgs
    )
    {
        var processingAudits = await _context
            .ProcessingAudits.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return processingAudits.ConvertAll(processingAudit => processingAudit.ToDto());
    }

    /// <summary>
    /// Get one ProcessingAudit
    /// </summary>
    public async Task<ProcessingAudit> ProcessingAudit(ProcessingAuditWhereUniqueInput uniqueId)
    {
        var processingAudits = await this.ProcessingAudits(
            new ProcessingAuditFindManyArgs
            {
                Where = new ProcessingAuditWhereInput { Id = uniqueId.Id }
            }
        );
        var processingAudit = processingAudits.FirstOrDefault();
        if (processingAudit == null)
        {
            throw new NotFoundException();
        }

        return processingAudit;
    }

    /// <summary>
    /// Meta data about ProcessingAudit records
    /// </summary>
    public async Task<MetadataDto> ProcessingAuditsMeta(ProcessingAuditFindManyArgs findManyArgs)
    {
        var count = await _context.ProcessingAudits.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one ProcessingAudit
    /// </summary>
    public async Task UpdateProcessingAudit(
        ProcessingAuditWhereUniqueInput uniqueId,
        ProcessingAuditUpdateInput updateDto
    )
    {
        var processingAudit = updateDto.ToModel(uniqueId);

        _context.Entry(processingAudit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProcessingAudits.Any(e => e.Id == processingAudit.Id))
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
