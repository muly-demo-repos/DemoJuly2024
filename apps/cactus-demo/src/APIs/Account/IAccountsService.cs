using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IAccountsService
{
    /// <summary>
    /// Get a Users record for Account
    /// </summary>
    public Task<User> GetUsers(AccountWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Account records
    /// </summary>
    public Task<MetadataDto> AccountsMeta(AccountFindManyArgs findManyArgs);

    /// <summary>
    /// Create one Account
    /// </summary>
    public Task<Account> CreateAccount(AccountCreateInput account);

    /// <summary>
    /// Delete one Account
    /// </summary>
    public Task DeleteAccount(AccountWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Accounts
    /// </summary>
    public Task<List<Account>> Accounts(AccountFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Account
    /// </summary>
    public Task<Account> Account(AccountWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Account
    /// </summary>
    public Task UpdateAccount(AccountWhereUniqueInput uniqueId, AccountUpdateInput updateDto);
}
