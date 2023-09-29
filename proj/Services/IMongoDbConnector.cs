using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public interface IMongoDbConnector
    {
        public  Task<OwnerDto[]> GetOwners();
        public Task<HostDto[]> GetHosts();

        public Task<HostDto[]> GetActiveHosts();
    }
}