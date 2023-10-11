﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_CommerceApp.Security
{
    public class CustomApiKeyMiddleware
    {
        private readonly IConfiguration Configuration;
        private readonly RequestDelegate _next;
        const string API_KEY = "ApiKey";
        public CustomApiKeyMiddleware(RequestDelegate next,

        IConfiguration configuration)
        {
            _next = next;
            Configuration = configuration;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            bool success = httpContext.Request.Headers.TryGetValue
            ("x-api-key", out var apiKeyFromHttpHeader);
            if (!success)
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("The Api Key for accessing this endpoint is not available");
                return;
            }
            string api_key_From_Configuration = Configuration[API_KEY];
            if (!api_key_From_Configuration.Equals(apiKeyFromHttpHeader))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("The authentication key is incorrect : Unauthorized access");
                return;
            }
            await _next(httpContext);
        }
    }
}
