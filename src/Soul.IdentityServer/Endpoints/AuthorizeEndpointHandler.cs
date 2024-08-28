using Microsoft.AspNetCore.Http;
using Soul.IdentityServer.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul.IdentityServer.Endpoints
{
    internal class AuthorizeEndpointHandler : IEndpointHandler
    {
        public async Task HandleAsync(HttpContext context)
        {
            var response = new
            {
                Message = "Authorization successful"
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
