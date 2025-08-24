using MongoDB.Bson;
using MongoDB.Driver;
using RealEstateAPI.Domain.Entities;
using RealEstateAPI.Infrastructure.Interfaces;

namespace RealEstateAPI.Infrastructure.Repositories
{
    public class PropertyRepository(IMongoDatabase database) : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _properties = database.GetCollection<Property>("Property");
        private readonly IMongoCollection<PropertyImage> _images = database.GetCollection<PropertyImage>("PropertyImage");

        public async Task<List<Property>> GetPropertiesAsync(
            string? name,
            string? address,
            double? minPrice,
            double? maxPrice,
            int pageNumber,
            int pageSize)
        {
            var filter = Builders<Property>.Filter.Empty;

            if (!string.IsNullOrEmpty(name) && !name.Equals("null", StringComparison.OrdinalIgnoreCase))
                filter &= Builders<Property>.Filter.Regex(nameof(Property.Name),
                    new BsonRegularExpression(name, "i"));

            if (!string.IsNullOrEmpty(address) && !address.Equals("null", StringComparison.OrdinalIgnoreCase))
                filter &= Builders<Property>.Filter.Regex(nameof(Property.Address),
                    new BsonRegularExpression(address, "i"));

            if (minPrice.HasValue)
                filter &= Builders<Property>.Filter.Gte(nameof(Property.Price), minPrice.Value);

            if (maxPrice.HasValue)
                filter &= Builders<Property>.Filter.Lte(nameof(Property.Price), maxPrice.Value);

            return await _properties
                .Find(filter)
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        public async Task<PropertyImage?> GetFirstEnabledImageAsync(string propertyId)
        {
            return await _images.Find(img => img.IdProperty == propertyId && img.Enabled)
                                .FirstOrDefaultAsync();
        }
    }
}