using FluentAssertions;
using SaaSPlatform.Domain.Entities.Customer;

namespace SaaSPlatform.Domain.Tests.Entities.Customers;

public class EmailTests
{
    [Fact]
    public void Constructor_Should_Create_Email_When_Value_Is_Valid()
    {
        // Arrange

        var validEmailAddress = "chia.karimi@gmail.com";

        // Act 

        var email = new Email(validEmailAddress);

        // Assert

        email.Value.Should().Be(validEmailAddress);

        email.ToString().Should().Be(validEmailAddress);
    }

    [Fact]
    public void Constructor_Should_ThrowException_When_Email_Is_Empty()
    {

        // Act
        Action act = () =>
        {
            new Email(string.Empty);
        };

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("*Email address is required*");
    }

    [Fact]
    public void Constructor_Should_Throw_When_Email_Is_Not_Valid()
    {
        // Act

        Action act = () =>
        {
            new Email("chia.karimi");
        };

        //Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("*The email address is not valid*");
    }
}
