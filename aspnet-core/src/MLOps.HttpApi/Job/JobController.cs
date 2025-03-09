using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MLOps.Dto.Job;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MLOps.Job;

[Area(MLOpsRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MLOpsRemoteServiceConsts.RemoteServiceName)]
[Route("api/MLOps/job")]
public class JobController: MLOpsController
{


}