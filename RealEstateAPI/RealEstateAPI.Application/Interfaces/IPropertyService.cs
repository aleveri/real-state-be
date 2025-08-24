using RealEstateAPI.Application.Dtos;

namespace RealEstateAPI.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetFilteredPropertiesAsync(
            string? name,
            string? address,
            double? minPrice,
            double? maxPrice,
            int pageNumber,
            int pageSize);
    }
}
