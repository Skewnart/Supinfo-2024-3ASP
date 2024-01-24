
using Microsoft.AspNetCore.Server.HttpSys;
using SchoolAPI.Services;
using System.Reflection;

namespace SchoolAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.WebHost.UseHttpSys(o =>
            //{
            //    o.AllowSynchronousIO = false;
            //    o.Authentication.Schemes = AuthenticationSchemes.None;
            //    o.Authentication.AllowAnonymous = true;
            //    o.MaxConnections = null;
            //    o.MaxRequestBodySize = 31457280;
            //});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Version = "v1",
                    Title = "School API"
                });

                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddCors(c =>
            {
                c.AddDefaultPolicy(p =>
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                });

                c.AddPolicy("MyCustomPolicy", p =>
                {
                    p.AllowAnyOrigin();
                    p.WithMethods("GET");
                });
            });

            builder.Services.AddSingleton<ISchoolAPI, SchoolEFService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}