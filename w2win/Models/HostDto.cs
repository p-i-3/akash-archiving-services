using MongoDB.Bson;

namespace Proj.Models
{
    public record HostDto
    {
        public required string ownerId { get; init; }
        public required string HostName {get;init;}
        public required string jsonDataBase64 { get; set; }
        public required DateTime PollDate {get;init; }
        public required bool Active {get;init;}
        public required string BatchId {get;init;}
    }
}