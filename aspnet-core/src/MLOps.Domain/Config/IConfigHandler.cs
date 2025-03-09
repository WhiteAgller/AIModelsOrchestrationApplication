using System.Threading.Tasks;
using MLOps.Entities.Config;
using Volo.Abp.Domain.Services;

namespace MLOps.Config;

public interface IConfigHandler: IDomainService
{
    Task<ConfigEntity> GetByUserId();

    Task<string> GetConfigItem(Configuration item);
}