using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using MLOps.Config;
using MLOps.Consts;
using Volo.Abp.Domain.Services;

namespace MLOps.Converter;

public class URLConverter : DomainService, IURLConverter
{
    private readonly IConfigHandler _configHandler;

    public URLConverter(IConfigHandler configHandler)
    {
        _configHandler = configHandler;
    }
    public async Task<string> ConvertURLtoURI(string url)
    {
        var subscription = await _configHandler.GetConfigItem(Configuration.Subscription);
        var resourceGroup = await _configHandler.GetConfigItem(Configuration.ResourceGroup);
        var workspace = await _configHandler.GetConfigItem(Configuration.Workspace);
        
        var sb = new StringBuilder("", 200);
        sb.Append("azureml://");
        
        // SUBSCRIPTION
        sb.Append($"subscriptions/{subscription}/");
        
        // RESOURCE GROUP
        sb.Append($"resourcegroups/{resourceGroup}/");
        
        // WORKSPACE
        sb.Append($"workspaces/{workspace}/");
        
        // DATASTORE
        sb.Append($"datastores/workspaceblobstore/");
        
        //PATH
        sb.Append($"paths/{GetFilePath(url)}");
        return sb.ToString();
    }

    private string GetFilePath(string url)
    {
        Regex r = new Regex(@"[^\/]+\/\/[^\/]+\/[^\/]+\/(.+)");
        return r.Matches(url)[0].Groups[1].Value;
    }
}