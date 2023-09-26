using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public class AkashApiConnector : IAkashApiConnector
    {
        public async Task<DummyData[]> GetDummyData()
        {
            return new DummyData[]{
                new DummyData
                {
                    Data = "Dog Eats Water",
                    Performance = 10,
                    Active = true,
                    ProviderName = "LondonLand",
                    ProviderId = new ObjectId()

                }
            };
        }
    }
}