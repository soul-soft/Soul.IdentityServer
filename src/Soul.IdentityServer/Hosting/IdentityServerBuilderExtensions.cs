using Soul.IdentityServer.Endpoints;
using Soul.IdentityServer.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerBuilderExtensions
    {
        public static void AddRequiredEndpoints(this IdentityServerBuilder builder)
        {
            builder.AddEndpointHandler<TokenEndpointHandler>("token");
            builder.AddEndpointHandler<AuthorizeEndpointHandler>("authorize");
        }
    }
}
