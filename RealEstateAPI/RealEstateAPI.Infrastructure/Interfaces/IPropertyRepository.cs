using RealEstateAPI.Domain.Entities;

namespace RealEstateAPI.Infrastructure.Interfaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetPropertiesAsync(string? name, string? address, double? minPrice, double? maxPrice, int pageNumber, int pageSize);
        Task<PropertyImage?> GetFirstEnabledImageAsync(string propertyId);
    }
}