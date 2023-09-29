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

        public async Task<OwnerDto[]> GetOwners()
        {
            var collection = _client.GetDatabase("TogaProjse").GetCollection<OwnerDto>("Owners");
            var filter = Builders<OwnerDto>.Filter.Empty;
            var docs = await collection.Find(filter).ToListAsync();
            return docs.ToArray();
        }
        public async Task<HostDto[]> GetHosts()
        {
            var collection = _client.GetDatabase("TogaProjse").GetCollection<HostDto>("Hosts");
            var filter = Builders<HostDto>.Filter.Empty;
            var docs = await collection.Find(filter).ToListAsync();
            return docs.ToArray();
        }
        public async Task<HostDto[]> GetActiveHosts()
        {
            var collection = _client.GetDatabase("TogaProjse").GetCollection<HostDto>("Hosts");
            var filter = Builders<HostDto>.Filter.Where(x => x.Active);
            var docs = await collection.Find(filter).ToListAsync();
            return docs.ToArray();
        }
    }
}