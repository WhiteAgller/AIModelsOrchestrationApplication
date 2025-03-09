using MLOps.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MLOps;

public abstract class MLOpsController : AbpControllerBase
{
    protected MLOpsController()
    {
        LocalizationResource = typeof(MLOpsResource);
    }
}
