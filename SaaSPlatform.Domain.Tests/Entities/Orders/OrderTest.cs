using FluentAssertions;
using SaaSPlatform.Domain.Entities.Order;

namespace SaaSPlatform.Domain.Tests.Entities.Orders;

public class OrderTest
{
    [Fact]
    public void CreateOrder_Should_Set_Properties_Correctly()
    {
        // Arrange 
        var customerId = Guid.NewGuid();

        // Act
        var order = new Order(customerId);

        // Assert

        order.CustomerId.Should().Be(customerId);
    }

    [Fact]
    public void Constructor_Should_Create_Order()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        // Act 

        Order order = new Order(customerId);

        // Assert

        order.CustomerId.Should().Be(customerId);
        order.Items.Should().BeEmpty();
        order.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void AddItem_Should_Add_Item_To_Order()
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        order.AddItem("Laptop", 1000m, 1);

        // Assert

        order.Items.Count.Should().Be(1);

        var item = order.Items.First();

        item.ProductName.Should().Be("Laptop");
        item.UnitPrice.Should().Be(1000m);
        item.Quantity.Should().Be(1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AddItem_Should_Throw_When_Quantity_Is_Invalid(int quantity)
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        Action act = () =>
        {
            order.AddItem("Laptop", 2000m, quantity);
        };

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("*Quantity must be > 0*");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void AddItem_Should_Throw_When_UnitPrice_Is_Invalid(decimal unitPrice)
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        Action act = () => 
        {
            order.AddItem("Laptop", unitPrice, 5);
        };

        // Assert

        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("*Unit price must be > 0*");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void AddItem_Should_Throw_When_ProductName_Is_Null(string productName)
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        Action act = () =>
        {
            order.AddItem(productName, 1000m, 5);
        };

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("*Product name is required*");
    }

    [Fact]
    public void GetTotal_Should_Return_Total_For_Signal_Item()
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        order.AddItem("Laptop", 1000m, 2);

        // Assert
        order.TotalAmount.Should().Be(2000m);
    }

    [Fact]
    public void GetTotal_Should_Return_Total_For_Multiple_Items()
    {
        // Arrange
        var order = new Order(Guid.NewGuid());

        // Act
        order.AddItem("Mobile", 1500m, 2);
        order.AddItem("Laptop", 1000m, 2);
        order.AddItem("Adapter", 50m, 1);

        // Assert
        order.TotalAmount.Should().Be(5050m);
    }
}