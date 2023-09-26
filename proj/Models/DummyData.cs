using MongoDB.Bson;

namespace Proj.Models
{
    public class DummyData
    {
        public required ObjectId Id { get; set; }
        public required string Data { get; set; }
        public required double Performance { get; set; }
        public required bool Active { get; set; }
        public required string ProviderName { get; set; }
        public required ObjectId ProviderId { get; set; }
    }
}