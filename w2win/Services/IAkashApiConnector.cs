using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public interface IAkashApiConnector
    {
        public Task<DummyData[]> GetDummyData();
    }
}