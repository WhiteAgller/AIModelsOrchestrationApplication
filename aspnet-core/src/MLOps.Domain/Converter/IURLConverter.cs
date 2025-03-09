using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MLOps.Converter;

public interface IURLConverter : IDomainService
{
    Task<string> ConvertURLtoURI(string url);
}