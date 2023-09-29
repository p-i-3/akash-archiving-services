using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public class MongoDbConnector : IMongoDbConnector
    {
        private const string _connectionString = "mongodb+srv://bigdickjohn:2jrCQBpK89HaJDbZ@testtest.svh09.mongodb.net/?authSource=admin";
        private readonly MongoClient _client;
        public MongoDbConnector()
        {
            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            _client = new MongoClient(settings);
        }

        public async Task<bool> UploadHosts(HostDto[] hosts)
        {
            try
            {
                var collection = _client.GetDatabase("TogaProjse").GetCollection<HostDto>("Hosts");
                await collection.InsertManyAsync(hosts);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }


        public async Task<bool> UploadOwners(OwnerDto[] owners)
        {
            try
            {
                var collection = _client.GetDatabase("TogaProjse").GetCollection<OwnerDto>("Owners");
                await collection.InsertManyAsync(owners);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}