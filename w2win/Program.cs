using NSwag.SwaggerGeneration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Proj.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Microsoft.OpenApi.Models;
namespace proj
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {

                webBuilder.ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ISecretsHolder,SecretsHolder>();
                    services.AddSingleton<IMongoDbConnector, MongoDbConnector>();
                    services.AddSingleton<IAkashApiConnector,AkashApiConnector>();
                    services.AddControllers();
                    services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "OUR API",
                            Version = "1"
                        });
                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                        options.IncludeXmlComments(xmlPath);
                    });

                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {

                })
                .ConfigureKestrel((hostContext, options) =>
                {

                })
                .UseUrls("http://localhost:4269")
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    }).UseSwagger()
                    .UseSwaggerUI(options => {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json","OUR API");
                    });
                });
            }).Build();

            host.Run();
        }
    }
}