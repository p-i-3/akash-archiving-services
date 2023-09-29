using MongoDB.Bson;

namespace Proj.Models
{
    public record Pagination
    {
        public string next_key { get; set; }
        public string total { get; set; }
    }
}