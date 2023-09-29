using MongoDB.Bson;

namespace Proj.Models
{
    public record Attribute
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}