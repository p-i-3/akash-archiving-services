using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using Proj.Models;

namespace Proj.Services
{
    public interface IMongoDbConnector
    {
        public Task<bool> UploadOwners(OwnerDto[] owners);
        public Task<bool> UploadHosts(HostDto[] hosts);

    }
}