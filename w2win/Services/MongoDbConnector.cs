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
        public MongoDbConnector(){
            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            _client = new MongoClient(settings);
        }

        public async Task<bool> UploadDummyData(DummyData[] dummyDatas){
            var collection = _client.GetDatabase("TogaProj").GetCollection<DummyData>("DummyData");
            await collection.InsertManyAsync(dummyDatas);
            return true;
        }

    }
}