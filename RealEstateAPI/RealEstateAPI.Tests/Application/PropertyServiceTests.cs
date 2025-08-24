using Moq;
using RealEstateAPI.Application.Services;
using RealEstateAPI.Domain.Entities;
using RealEstateAPI.Infrastructure.Interfaces;

namespace RealEstateAPI.Tests.Application
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _mockRepository = null!;
        private PropertyService _service = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPropertyRepository>();
            _service = new PropertyService(_mockRepository.Object);
        }

        [Test]
        public async Task GetFilteredPropertiesAsync_ReturnsMappedDtos()
        {
            // Arrange: mock Property entities
            var mockProperties = new List<Property>
            {
                new() {
                    Id = "prop1",
                    IdOwner = "owner1",
                    Name = "Test House",
                    Address = "123 Main St",
                    Price = 500000
                }
            };

            // Mock images
            var mockImage = new PropertyImage
            {
                Id = "img1",
                IdProperty = "prop1",
                File = "house.jpg",
                Enabled = true
            };

            _mockRepository.Setup(r => r.GetPropertiesAsync(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double?>(), It.IsAny<double?>(),
                It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(mockProperties);

            _mockRepository.Setup(r => r.GetFirstEnabledImageAsync("prop1"))
                .ReturnsAsync(mockImage);

            // Act
            var result = await _service.GetFilteredPropertiesAsync("House", "Main", 100000, 600000, 1, 10);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Name, Is.EqualTo("Test House"));
                Assert.That(result[0].Image, Is.EqualTo("house.jpg"));
            });
        }

        [Test]
        public async Task GetFilteredPropertiesAsync_ReturnsEmptyList_WhenNoPropertiesFound()
        {
            // Arrange: empty repo response
            _mockRepository.Setup(r => r.GetPropertiesAsync(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double?>(), It.IsAny<double?>(),
                It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync([]);

            // Act
            var result = await _service.GetFilteredPropertiesAsync("House", "Main", 100000, 600000, 1, 10);

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}