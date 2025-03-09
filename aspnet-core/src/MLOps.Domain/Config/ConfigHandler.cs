using System;
using System.Threading.Tasks;
using MLOps.Entities.Config;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace MLOps.Config;

public class ConfigHandler: IConfigHandler
{
    private readonly IRepository<ConfigEntity, Guid> _configRepository;
    private readonly ICurrentUser _currentUser;

    public ConfigHandler(IRepository<ConfigEntity, Guid> configRepository, ICurrentUser currentUser)
    {
        _configRepository = configRepository;
        _currentUser = currentUser;
    }
    
    public async Task<ConfigEntity> GetByUserId()
    {
        var a = _currentUser.IsAuthenticated;
        var entites = await _configRepository.GetListAsync();
        var entity = entites.Find(entity => entity.UserId == _currentUser.Id);

        if (entity == null)
        {
            throw new Exception("No configuration was found.");
        }

        return entity;
    }

    public async Task<string> GetConfigItem(Configuration item)
    {
        var config = await GetByUserId();
        
        var propertyInfo = typeof(ConfigEntity).GetProperty(item.ToString());
        if (propertyInfo != null)
        {
            object? propertyValue = propertyInfo.GetValue(config);
            if (propertyValue != null)
            {
                return propertyValue.ToString()!;
            }
        }
        else
        {
            throw new Exception("Invalid property name");
        }

        return "";
    }
}