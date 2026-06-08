using FluentAssertions;
using SaaSPlatform.Domain.Entities.Product;

namespace SaaSPlatform.Domain.Tests.Entities.Products;

public class ProductTests
{
    [Fact]
    public void CreateProduct_Should_Set_Properties_Correctly()
    {
        // Arrange
        var productName = "Test";
        var price = 18m;

        // Act
        var product = new Product(productName, price);

        // Assert

        product.Name.Should().Be(productName);
        product.Price.Should().Be(price);
    }
}
