using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using App.Models;

namespace App.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Main action for the Auth Middleware.
        /// </summary>
        /// <returns>void value</returns>
        /// <param name="context">HttpContext of the application</param>
        public async Task Invoke(HttpContext context)
        {
            var xApiKey = Environment.GetEnvironmentVariable("API_KEY");
            var path = context.Request.Path;

            if (path.Value != "/ping")
            {
                var headers = context.Request?.Headers["X-Api-Key"];

                if (headers.ToString() != xApiKey)
                {
                    var error = new Response().Get(
                        401,
                        "error",
                        "Unauthorized",
                        path.Value
                    );

                    context.Response.StatusCode = 401; //UnAuthorized
                    context.Response.Headers.Add("Content-Type", "application/json");

                    var message = JsonConvert.SerializeObject(error).Replace("\"Object\"", "\"object\"");
                    await context.Response.WriteAsync(message);
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
