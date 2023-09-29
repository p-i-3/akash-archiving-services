
    using MongoDB.Bson;

namespace Proj.Models
{
    public record Root
    {
        public List<Provider> providers { get; set; }
        public Pagination pagination { get; set; }
    }

}