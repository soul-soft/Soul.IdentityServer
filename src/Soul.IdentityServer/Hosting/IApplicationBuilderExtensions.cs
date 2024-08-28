using Soul.IdentityServer.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseIdentityServer(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<IdentityServerRoutingMiddleware>();
        }
    }
}
