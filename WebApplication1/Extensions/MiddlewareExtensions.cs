using WebApplication1.Middleware;

namespace WebApplication1.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTextResponse(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<TextResponseMiddleware>();
        }
    }
}
