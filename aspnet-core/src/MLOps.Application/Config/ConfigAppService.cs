using System;
using System.Threading.Tasks;
using MLOps.Dto.Config;
using MLOps.Entities.Config;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace MLOps.Config;

public class ConfigAppService: MLOpsAppService, IConfigAppService
{
    private IRepository<ConfigEntity, Guid> _configRepository;
    
    public ConfigAppService(IRepository<ConfigEntity, Guid> configRepository)
    {
        _configRepository = configRepository;
    }

    public async Task<ConfigDto> Create(ConfigDto input)
    {
        var item = await _configRepository.InsertAsync(
            new ConfigEntity()
            {
                Subscription = input.Subscription,
                ResourceGroup = input.ResourceGroup,
                Workspace = input.Workspace,
                WorkspaceId = input.WorkspaceId,
                TenantId = input.TenantId,
                StorageKey = input.StorageKey,
                LogBlobContainerName = input.LogBlobContainerName,
                DataBlobContainerName = input.DataBlobContainerName,
                LogFolderPath = input.LogFolderPath,
                DataFolderPath = input.DataFolderPath,
                ClientId = input.ClientId,
                ClientSecret = input.ClientSecret,
                UserId = CurrentUser.Id!.Value
            });
        return ObjectMapper.Map<ConfigEntity, ConfigDto>(item);
    }
    
    public async Task<ConfigDto> UpdateAsync(ConfigDto input)
    {
        var entity = await _configRepository.GetAsync(input.Id);

        if (entity == null)
        {
            throw new Exception("Entity wasn't found");
        }

        entity.Subscription = input.Subscription;
        entity.ResourceGroup = input.ResourceGroup;
        entity.Workspace = input.Workspace;
        entity.WorkspaceId = input.WorkspaceId;
        entity.TenantId = input.TenantId;
        entity.StorageKey = input.StorageKey;
        entity.LogBlobContainerName = input.LogBlobContainerName;
        entity.DataBlobContainerName = input.DataBlobContainerName;
        entity.LogFolderPath = input.LogFolderPath;
        entity.DataFolderPath = input.DataFolderPath;
        entity.ClientId = input.ClientId;
        entity.ClientSecret = input.ClientSecret;
        entity.UserId = CurrentUser.Id!.Value;

        return ObjectMapper.Map<ConfigEntity, ConfigDto>(entity);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _configRepository.DeleteAsync(id);
    }

    public async Task<ConfigDto> GetAsync(Guid id)
    {
        var entity = await _configRepository.GetAsync(id);
        if (entity == null)
        {
            throw new Exception("Entity wasn't found");
        }
        return ObjectMapper.Map<ConfigEntity, ConfigDto>(entity);
    }

    public async Task<ConfigDto> GetByUserId()
    {
        var entites = await _configRepository.GetListAsync();
        
        var entity = entites.Find(entity => CurrentUser.Id != null && entity.UserId == CurrentUser.Id.Value);
        
        return ObjectMapper.Map<ConfigEntity, ConfigDto>(entity);
        
    }
    
}