using MongoDB.Bson;

namespace Proj.Models
{
    public record Info
    {
        public string email { get; set; }
        public string website { get; set; }
    }
}