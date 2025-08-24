using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Application.Interfaces;

namespace RealEstateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController(IPropertyService propertyService) : ControllerBase
    {
        [HttpGet("filter/{name}/{address}/{minPrice:double}/{maxPrice:double}/{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetProperties(
            string name,
            string address,
            double minPrice,
            double maxPrice,
            int pageNumber,
            int pageSize)
        {
            if (minPrice < 0 || maxPrice < 0)
                return BadRequest(new { error = "Price values must be positive." });

            if (minPrice > maxPrice)
                return BadRequest(new { error = "minPrice cannot be greater than maxPrice." });

            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest(new { error = "pageNumber and pageSize must be greater than 0." });

            var result = await propertyService.GetFilteredPropertiesAsync(
                name, address, minPrice, maxPrice, pageNumber, pageSize);

            if (result == null || !result.Any())
                return NotFound(new { message = "No properties found with the given filters." });

            return Ok(new
            {
                pageNumber,
                pageSize,
                results = result
            });
        }
    }
}