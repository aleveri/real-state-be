using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateAPI.Domain.Entities
{
    public class PropertyImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdProperty { get; set; } = string.Empty;

        [BsonElement("file")]
        public string File { get; set; } = string.Empty;

        [BsonElement("Enabled")]
        public bool Enabled { get; set; }
    }
}
