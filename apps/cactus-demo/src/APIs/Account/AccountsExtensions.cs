using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class AccountsExtensions
{
    public static Account ToDto(this AccountDbModel model)
    {
        return new Account
        {
            Id = model.Id,
            TypeField = model.TypeField,
            Provider = model.Provider,
            ProviderAccountId = model.ProviderAccountId,
            RefreshToken = model.RefreshToken,
            AccessToken = model.AccessToken,
            ExpiresAt = model.ExpiresAt,
            TokenType = model.TokenType,
            Scope = model.Scope,
            IdToken = model.IdToken,
            SessionState = model.SessionState,
            Users = model.UsersId,
        };
    }

    public static AccountDbModel ToModel(
        this AccountUpdateInput updateDto,
        AccountWhereUniqueInput uniqueId
    )
    {
        var account = new AccountDbModel
        {
            Id = uniqueId.Id,
            RefreshToken = updateDto.RefreshToken,
            AccessToken = updateDto.AccessToken,
            ExpiresAt = updateDto.ExpiresAt,
            TokenType = updateDto.TokenType,
            Scope = updateDto.Scope,
            IdToken = updateDto.IdToken,
            SessionState = updateDto.SessionState
        };

        // map required fields
        if (updateDto.TypeField != null)
        {
            account.TypeField = updateDto.TypeField;
        }
        if (updateDto.Provider != null)
        {
            account.Provider = updateDto.Provider;
        }
        if (updateDto.ProviderAccountId != null)
        {
            account.ProviderAccountId = updateDto.ProviderAccountId;
        }

        return account;
    }
}
