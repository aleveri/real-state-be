using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateAPI.Domain.Entities
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdOwner { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("Address")]
        public string Address { get; set; } = string.Empty;
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("Year")]
        public int Year { get; set; }
        [BsonElement("CodeInternal")]
        public string CodeInternal { get; set; } = string.Empty;
    }
}
