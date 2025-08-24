using RealEstateAPI.Application.Dtos;
using RealEstateAPI.Application.Interfaces;
using RealEstateAPI.Infrastructure.Interfaces;
using RealEstateAPI.Infrastructure.Repositories;

namespace RealEstateAPI.Application.Services
{
    public class PropertyService(IPropertyRepository repository) : IPropertyService
    {
        public async Task<List<PropertyDto>> GetFilteredPropertiesAsync(
            string? name,
            string? address,
            double? minPrice,
            double? maxPrice,
            int pageNumber,
            int pageSize)
        {
            var properties = await repository.GetPropertiesAsync(name, address, minPrice, maxPrice, pageNumber, pageSize);

            var result = new List<PropertyDto>();

            foreach (var property in properties)
            {
                var image = await repository.GetFirstEnabledImageAsync(property.Id);

                result.Add(new PropertyDto
                {
                    IdOwner = property.IdOwner,
                    Name = property.Name,
                    Address = property.Address,
                    Price = property.Price,
                    Image = image?.File
                });
            }

            return result;
        }
    }
}