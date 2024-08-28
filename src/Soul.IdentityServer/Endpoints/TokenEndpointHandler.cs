using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Soul.IdentityModel;
using Soul.IdentityServer.Exceptions;
using Soul.IdentityServer.Hosting;
using Soul.IdentityServer.Validation;

namespace Soul.IdentityServer.Endpoints
{
    internal class TokenEndpointHandler : IEndpointHandler
    {
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IdentityServerOptions _options;
        private readonly ClientCredentialstParsers _clientSecretParsers;
        private readonly IClientSecretValidator _clientSecretValidator;

        public TokenEndpointHandler(
            IClientStore clientStore,
            IResourceStore resourceStore,
            IdentityServerOptions options,
            ClientCredentialstParsers clientSecretParsers,
            IClientSecretValidator clientSecretValidator)
        {
            _options = options;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _clientSecretParsers = clientSecretParsers;
            _clientSecretValidator = clientSecretValidator;
        }

        public async Task HandleAsync(HttpContext context)
        {
            // 验证请求方法是否为POST
            if (context.Request.Method != HttpMethods.Post)
            {
                throw new InvalidRequestException("invalid_request", "Method not allowed");
            }

            // 验证Content-Type是否为application/x-www-form-urlencoded
            if (!context.Request.HasFormContentType)
            {
                throw new InvalidRequestException("invalid_request", "Invalid content type");
            }
          
            // 读取请求参数
            var form = await context.Request.ReadFormAsync();
            var request = new TokenRequestParameters
            {
                GrantType = form["grant_type"],
                Code = form["code"],
                RedirectUri = form["redirect_uri"],
                ClientId = form["client_id"],
                ClientSecret = form["client_secret"],
                Scope = form["scope"],
                RefreshToken = form["refresh_token"]
            };

            // 验证必需的参数
            if (string.IsNullOrEmpty(request.GrantType))
            {
                throw new InvalidRequestException("invalid_request", "The 'grant_type' parameter is missing.");
            }

            if (string.IsNullOrEmpty(request.ClientId))
            {
                throw new InvalidRequestException("invalid_request", "The 'client_id' parameter is missing.");
            }
            
            //获取client
            var client = await _clientStore.FindClientByIdAsync(request.ClientId);
            
            if (client == null)
            {
                throw new InvalidRequestException("invalid_request", "The client secret is missing or invalid.");
            }

            //解析clientSecret
            var clientSecretParsed = await _clientSecretParsers.ParseAsync(context) ?? throw new InvalidRequestException("invalid_request", "Client secret validation failed. Please check your credentials.");

            //验证clientSecret
            var clientSecretValidateResult = await _clientSecretValidator.ValidateAsync(client, clientSecretParsed);
            if (!clientSecretValidateResult)
            {
                throw new InvalidRequestException("invalid_request", "?");
            }

            // 获取资源
            var resources = await _resourceStore.GetResourcesByScopeAsync(request.Scope);

            // 示例响应
            await context.Response.WriteAsJsonAsync(new { Token = "123456" });
        }
    }
}
