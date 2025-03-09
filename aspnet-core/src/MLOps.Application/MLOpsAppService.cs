using MLOps.Localization;
using Volo.Abp.Application.Services;

namespace MLOps;

/* Inherit your application services from this class.
 */
public abstract class MLOpsAppService : ApplicationService
{
    protected MLOpsAppService()
    {
        LocalizationResource = typeof(MLOpsResource);
        ObjectMapperContext = typeof(MLOpsApplicationModule);
    }
}
