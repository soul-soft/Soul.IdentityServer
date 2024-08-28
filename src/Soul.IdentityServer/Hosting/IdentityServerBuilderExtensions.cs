﻿using Soul.IdentityModel;
using Soul.IdentityServer.Endpoints;
using Soul.IdentityServer.Hosting;
using Soul.IdentityServer.Stores;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerBuilderExtensions
    {
        internal static IdentityServerBuilder AddRequiredEndpoints(this IdentityServerBuilder builder)
        {
            builder.AddEndpointHandler<TokenEndpointHandler>("token");
            builder.AddEndpointHandler<AuthorizeEndpointHandler>("authorize");
            return builder;
        }

        public static IdentityServerBuilder AddResourceStore(
            this IdentityServerBuilder builder,
            IEnumerable<ApiScope> apiScopes,
            IEnumerable<ApiResource> apiResources,
            IEnumerable<IdentityResource> identityResources)
        {
            return builder.AddResourceStore(sp =>
            {
                return new MemoryResourceStore(apiScopes, apiResources, identityResources);
            });
        }
    }
}
