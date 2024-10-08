﻿using Microsoft.Extensions.Options;
using Soul.IdentityModel;
using Soul.IdentityServer.Endpoints;
using Soul.IdentityServer.Hosting;
using Soul.IdentityServer.Stores;
using Soul.IdentityServer.Validation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerBuilderExtensions
    {
        internal static IdentityServerBuilder AddIdentityServerCore(this IdentityServerBuilder builder)
        {
            builder.ConfigureOptions(configureOptions => { });
            builder.Services.AddSingleton(sp => 
            {
                return sp.GetRequiredService<IOptions<IdentityServerOptions>>().Value;
            });
            builder.Services.AddTransient<ClientCredentialstParsers>();
            builder.AddEndpointHandler<TokenEndpointHandler>("token");
            builder.AddEndpointHandler<AuthorizeEndpointHandler>("authorize");
            builder.AddClientSecretParser<FromFormHashClientCredentialsParser>();
            return builder;
        }

        public static IdentityServerBuilder AddClientStore(this IdentityServerBuilder builder,IEnumerable<Client> clients)
        {
            return builder.AddClientStore(sp =>
            {
                return new MemoryClientStore(clients);
            });
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
