using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public interface IAkashApiConnector
    {
        public Task<HostDto[]> GetHostData(OwnerDto[] ownerDtos,string batchId);
        public Task<OwnerDto[]> GetOwnerData(string batchId);
    }
}