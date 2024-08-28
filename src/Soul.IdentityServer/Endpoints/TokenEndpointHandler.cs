using Microsoft.AspNetCore.Http;
using Soul.IdentityModel;
using Soul.IdentityServer.Exceptions;
using Soul.IdentityServer.Hosting;

namespace Soul.IdentityServer.Endpoints
{
    public class TokenEndpointHandler : IEndpointHandler
    {
        private readonly IClientStore _clientStore;

        public TokenEndpointHandler(IClientStore clientStore)
        {
            _clientStore = clientStore;
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

            var client = await _clientStore.FindClientByIdAsync(request.ClientId);

            if (client == null)
            {
                throw new InvalidRequestException("invalid_request", "The client cannot be null. Please provide a valid client.");
            }

            // 示例响应
            await context.Response.WriteAsJsonAsync(new { Token = "123456" });
        }
    }
}
