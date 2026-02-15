using Claps.ProductCatalog.Application.Interfaces;
using Claps.ProductCatalog.Application.Services;
using Claps.ProductCatalog.Domain.Entities;
using Moq;


namespace Claps.ProductCatalog.Tests;

public class ProductServiceTests
{
    [Fact]
    public async Task Should_Create_Product_Successfully()
    {
        //Arrange
        var repositoryMock = new Mock<IProductRepository>();

        repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Product>()))
            .ReturnsAsync((Product p) => p);

        var service = new ProductService(repositoryMock.Object);

        //Act
        var result = await service.CreateAsync(
            "Teclado",
            "Teclado Gamer",
            100,
            "Games");

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Teclado", result.Name);
        Assert.Equal(100, result.Price);
    }
}