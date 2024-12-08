using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AccountsControllerBase : ControllerBase
{
    protected readonly IAccountsService _service;

    public AccountsControllerBase(IAccountsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get a User record for Account
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] AccountWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Account records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AccountsMeta(
        [FromQuery()] AccountFindManyArgs filter
    )
    {
        return Ok(await _service.AccountsMeta(filter));
    }

    /// <summary>
    /// Create one Account
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Account>> CreateAccount(AccountCreateInput input)
    {
        var account = await _service.CreateAccount(input);

        return CreatedAtAction(nameof(Account), new { id = account.Id }, account);
    }

    /// <summary>
    /// Delete one Account
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAccount([FromRoute()] AccountWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAccount(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Accounts
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Account>>> Accounts(
        [FromQuery()] AccountFindManyArgs filter
    )
    {
        return Ok(await _service.Accounts(filter));
    }

    /// <summary>
    /// Get one Account
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Account>> Account([FromRoute()] AccountWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Account(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Account
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAccount(
        [FromRoute()] AccountWhereUniqueInput uniqueId,
        [FromQuery()] AccountUpdateInput accountUpdateDto
    )
    {
        try
        {
            await _service.UpdateAccount(uniqueId, accountUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
