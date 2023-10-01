using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public class MongoDbConnector : IMongoDbConnector
    {
        private readonly MongoClient _client;
        public MongoDbConnector(ISecretsHolder secrets)
        {
            var settings = MongoClientSettings.FromConnectionString(secrets.GetSecret());
            _client = new MongoClient(settings);
        }

        public async Task<bool> UploadHosts(HostDto[] hosts)
        {
            return true;
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
            return true;
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