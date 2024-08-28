using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Soul.IdentityServer.Exceptions;

namespace Soul.IdentityServer.Hosting
{
    internal class IdentityServerRoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityServerRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IEnumerable<EndpointInfo> endpoints)
        {
            // 根据请求的路径决定路由到哪个 EndpointHandler
            if (!context.Request.Path.HasValue)
            {
                await _next(context);
                return;
            }

            var path = context.Request.Path.Value;
            var endpoint = endpoints.Where(a => $"/{a.Path}" == path)
                .FirstOrDefault();

            if (endpoint == null)
            {
                await _next(context);
                return;
            }

            try
            {
                var endpointHandler = (IEndpointHandler)context.RequestServices.GetRequiredService(endpoint.Type);
                await endpointHandler.HandleAsync(context);
            }
            catch (InvalidRequestException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Error,
                    error_description = ex.ErrorDescription
                });
            }
       
        }
    }
}
