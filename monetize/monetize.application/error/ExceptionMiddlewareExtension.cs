using Microsoft.AspNetCore.Builder;

namespace monetize.application.error
{
    public static class ExceptionMiddlewareExtension
    {
         public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}