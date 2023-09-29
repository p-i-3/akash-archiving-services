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
using Microsoft.Extensions.Configuration;
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
                    var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();
                    var abc = config.GetSection("MongoDb_Connection_String");
                    var connectionString = config["MongoDb_Connection_String"];
                    services.AddSingleton<ISecretsHolder,SecretsHolder>();
                    services.AddSingleton<IMongoDbConnector, MongoDbConnector>();
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
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowAnyOrigin",
                            builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                    });

                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {

                })
                .ConfigureKestrel((hostContext, options) =>
                {

                })
                .UseUrls("http://0.0.0.0:6942")
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseCors("AllowAnyOrigin");
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    }).UseSwagger()
                    .UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OUR API");
                    });
                });
            }).Build();
            host.Run();
        }
    }
}