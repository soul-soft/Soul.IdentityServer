using Microsoft.AspNetCore.Http;

namespace Soul.IdentityServer.Hosting
{
    public interface IEndpointHandler
    {
        Task HandleAsync(HttpContext context);
    }
}
