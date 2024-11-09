using Aegiss.Core.Services;
using JwtBuilder;
using Microsoft.IdentityModel.Tokens;

namespace Aegiss.Controllers.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next; //pra falar que foi validado, tá ok

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                await ReturnUnauthorizedResponse(context, "Token not found.");
                return;
            }

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ","");


            if (string.IsNullOrEmpty(token))
            {
                await ReturnUnauthorizedResponse(context, "Token is empty");
                return;
            }

            var validationResult = new TokenValidator();

            if (!validationResult.ValidateToken(token))
            {
                await ReturnUnauthorizedResponse(context, "Invalid Token");
                return;
            }

            await _next(context);
        }

        private async Task ReturnUnauthorizedResponse(HttpContext context, String message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(message);
        }
    }
}

