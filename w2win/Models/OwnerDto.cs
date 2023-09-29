using MongoDB.Bson;

namespace Proj.Models
{
    public record OwnerDto
    {
        public required string OwnerId { get; set; }

        public required Provider Provider { get; set; }

        public required DateTime PollDate { get; init;  }
        public required string BatchId {get; init;}
    }
}
