using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public class SecretsHolder : ISecretsHolder
    {
        public string MongoDb_Connection_String { get; set; }
        public string GetSecret()
        {
            var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();

            return config["MongoDb_Connection_String"];
        }
    }
}