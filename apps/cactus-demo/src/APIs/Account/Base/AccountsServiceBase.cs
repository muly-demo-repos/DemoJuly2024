using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class AccountsServiceBase : IAccountsService
{
    protected readonly CactusDemoDbContext _context;

    public AccountsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a Users record for Account
    /// </summary>
    public async Task<User> GetUsers(AccountWhereUniqueInput uniqueId)
    {
        var account = await _context
            .Accounts.Where(account => account.Id == uniqueId.Id)
            .Include(account => account.Users)
            .FirstOrDefaultAsync();
        if (account == null)
        {
            throw new NotFoundException();
        }
        return account.Users.ToDto();
    }

    /// <summary>
    /// Meta data about Account records
    /// </summary>
    public async Task<MetadataDto> AccountsMeta(AccountFindManyArgs findManyArgs)
    {
        var count = await _context.Accounts.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Create one Account
    /// </summary>
    public async Task<Account> CreateAccount(AccountCreateInput createDto)
    {
        var account = new AccountDbModel
        {
            TypeField = createDto.TypeField,
            Provider = createDto.Provider,
            ProviderAccountId = createDto.ProviderAccountId,
            RefreshToken = createDto.RefreshToken,
            AccessToken = createDto.AccessToken,
            ExpiresAt = createDto.ExpiresAt,
            TokenType = createDto.TokenType,
            Scope = createDto.Scope,
            IdToken = createDto.IdToken,
            SessionState = createDto.SessionState
        };

        if (createDto.Id != null)
        {
            account.Id = createDto.Id;
        }
        if (createDto.Users != null)
        {
            account.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AccountDbModel>(account.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Account
    /// </summary>
    public async Task DeleteAccount(AccountWhereUniqueInput uniqueId)
    {
        var account = await _context.Accounts.FindAsync(uniqueId.Id);
        if (account == null)
        {
            throw new NotFoundException();
        }

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Accounts
    /// </summary>
    public async Task<List<Account>> Accounts(AccountFindManyArgs findManyArgs)
    {
        var accounts = await _context
            .Accounts.Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return accounts.ConvertAll(account => account.ToDto());
    }

    /// <summary>
    /// Get one Account
    /// </summary>
    public async Task<Account> Account(AccountWhereUniqueInput uniqueId)
    {
        var accounts = await this.Accounts(
            new AccountFindManyArgs { Where = new AccountWhereInput { Id = uniqueId.Id } }
        );
        var account = accounts.FirstOrDefault();
        if (account == null)
        {
            throw new NotFoundException();
        }

        return account;
    }

    /// <summary>
    /// Update one Account
    /// </summary>
    public async Task UpdateAccount(AccountWhereUniqueInput uniqueId, AccountUpdateInput updateDto)
    {
        var account = updateDto.ToModel(uniqueId);

        _context.Entry(account).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Accounts.Any(e => e.Id == account.Id))
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
