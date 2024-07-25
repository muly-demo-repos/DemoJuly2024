using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class AppModelsExtensions
{
    public static AppModel ToDto(this AppModelDbModel model)
    {
        return new AppModel
        {
            Id = model.Id,
            DirName = model.DirName,
            Keys = model.Keys,
            Categories = model.Categories,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            ApiKey = model.ApiKey?.Select(x => x.Id).ToList(),
            Credential = model.Credential?.Select(x => x.Id).ToList(),
            Webhook = model.Webhook?.Select(x => x.Id).ToList(),
        };
    }

    public static AppModelDbModel ToModel(
        this AppModelUpdateInput updateDto,
        AppModelWhereUniqueInput uniqueId
    )
    {
        var appModel = new AppModelDbModel { Id = uniqueId.Id, Keys = updateDto.Keys };

        // map required fields
        if (updateDto.DirName != null)
        {
            appModel.DirName = updateDto.DirName;
        }
        if (updateDto.Categories != null)
        {
            appModel.Categories = updateDto.Categories.Value;
        }
        if (updateDto.CreatedAt != null)
        {
            appModel.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            appModel.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return appModel;
    }
}
