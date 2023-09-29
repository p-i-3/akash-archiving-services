using MongoDB.Bson;

namespace Proj.Models
{
    public record Provider
    {
        public string owner { get; set; }
        public string host_uri { get; set; }
        public List<Attribute> attributes { get; set; }
        public Info info { get; set; }
    }

}