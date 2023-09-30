using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace teahouse.Middlewares {
    public class SessionValidationMiddleware {

        private readonly RequestDelegate _next;

        public SessionValidationMiddleware(RequestDelegate next) {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context) {
            bool isAuthenticated = context.Session.GetInt32("UserId") != null;
            PathString path = context.Request.Path;

            if (!isAuthenticated && !IsWhitelistedPath(path)) {
                context.Response.Redirect("/Auth/Login");
                return;
            }

            if (isAuthenticated && IsLoginPage(path)) {
                context.Response.Redirect("/");
                return;
            }

            await _next(context);
        }

        public bool IsWhitelistedPath(PathString path) {
            return path.StartsWithSegments("/Auth/LoginUser") ||
                path.StartsWithSegments("/Auth/Login") ||
                path.StartsWithSegments("/Auth/Register") ||
                path.StartsWithSegments("/Auth/RegisterUser");
        }

        public bool IsLoginPage(PathString path) {
            return path.StartsWithSegments("/Auth/Login");
        }
    }
}
