using System.Threading.Tasks;
using RestSharp;
using Volo.Abp.Domain.Services;

namespace MLOps.Authentication;

public interface IMLOpsAuthenticator: IDomainService
{
    Task<string> GetToken();
}