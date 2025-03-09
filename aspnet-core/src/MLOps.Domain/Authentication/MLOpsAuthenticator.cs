using System.Threading.Tasks;
using MLOps.Authentication.Records;
using RestSharp;
using RestSharp.Authenticators;
using Volo.Abp.Domain.Services;

namespace MLOps.Authentication;

public class MLOpsAuthenticator : AuthenticatorBase, IAuthenticator, IMLOpsAuthenticator
{
    readonly string _baseUrl;
    readonly string _clientId;
    readonly string _clientSecret;
    
    public MLOpsAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
    {
        _baseUrl = baseUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
        return new HeaderParameter(KnownHeaders.Authorization, Token);
    }
    
    public async Task<string> GetToken()
    {
        var options = new RestClientOptions(_baseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret)
        };

        var client = new RestClient(options);

        var request = new RestRequest("")
            .AddParameter("grant_type", "client_credentials")
            .AddParameter("resource", "https://management.azure.com");
        var response = await client.PostAsync<TokenResponse>(request);
        return @"" + response.TokenType + " " + response.AccessToken + "";
    }
}