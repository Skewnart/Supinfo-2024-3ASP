namespace WebApplication1.Middleware
{
    public class TextResponseMiddleware
    {
        //Il faut le next
        private readonly RequestDelegate _next;

        public TextResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Et la méthode Invoke
        public async Task Invoke(HttpContext context, ILogger logger)
        {
            logger.LogInformation("Utilisation du logger injecté automatiquement");

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("Content-Type", "text/plain; charset=utf-8" );

                return Task.CompletedTask;
            }, context);
        }
    }
}
