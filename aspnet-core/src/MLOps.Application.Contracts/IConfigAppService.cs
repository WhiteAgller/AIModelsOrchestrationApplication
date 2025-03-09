using System.Threading.Tasks;
using MLOps.Dto.Config;

namespace MLOps;

public interface IConfigAppService
{
    Task<ConfigDto> GetByUserId();
}