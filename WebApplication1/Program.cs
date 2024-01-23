
using WebApplication1.Extensions;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
                
            builder.Services.AddSingleton<ILogger, LoggerService>();
            builder.Services.AddTransient<IDriver, HumanDriverService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Ici middleware anonyme
            app.Use(async (context, next) =>
            {
                app.Services.GetService<ILogger>().LogInformation("Ceci est le début de notre middleware anonyme");

                context.Response.OnStarting(state =>
                {
                    var httpContext = (HttpContext)state;
                    httpContext.Response.Headers.Add("X-Added-Header", "value");

                    return Task.CompletedTask;
                }, context);

                await next.Invoke();
            });

            //Ici middleware fait comme les autres, avec une méthode d'extension
            app.UseTextResponse();

            app.MapControllers();

            app.Run();
        }
    }
}