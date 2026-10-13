
using ApiVersioning.Models;
using ApiVersioning.Services;
using Asp.Versioning;
using Microsoft.OpenApi;

namespace ApiVersioning
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddControllers();
            builder.Services
     .AddApiVersioning(options =>
     {
         options.DefaultApiVersion = new ApiVersion(2, 0);
         options.AssumeDefaultVersionWhenUnspecified = false;
         options.ReportApiVersions = true;
         options.ApiVersionReader = new UrlSegmentApiVersionReader();
     })
     .AddMvc()
     .AddApiExplorer(options =>
     {
         options.GroupNameFormat = "'v'VVV";
         options.SubstituteApiVersionInUrl = true;
     });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Haseeb Mohamed",
                    Version = "v1"
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Haseeb Mohamed",
                    Version = "v2"
                });
            });
            builder.Services.AddScoped<IProductService, ProductService>();
            var app = builder.Build();

            // Configure middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Haseeb Mohamed v1");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Haseeb Mohamed v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
