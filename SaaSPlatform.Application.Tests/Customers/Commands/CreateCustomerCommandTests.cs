using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SaaSPlatform.Application.Features.Customers.Commands;
using SaaSPlatform.Application.Features.Customers.DTOs;
using SaaSPlatform.Application.Tests.Models;

namespace SaaSPlatform.Application.Tests.Customers.Commands;


public class CreateCustomerCommandTests
{
    private readonly DbContextFixture _contextFixture = new();

    [Fact]
    public async Task Handle_Should_Create_Customer()
    {
        // Arrange 
        await using var dbContext = _contextFixture.CreateDbContext();

        var handler = new CreateCustomerCommandHandler(dbContext);

        var customerDetailDto = new CustomerDetailDto
        {
            FirstName = "Chia",
            LastName = "Karimi",
            Email = "chia.karimi@gmail.com"
        };

        var request = new CreateCustomerCommand(customerDetailDto);

        // Act 
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().Be(true);
    }

    [Fact]
    public async Task Handle_Should_Create_Valid_Customer()
    {
        // Arrange 
        await using var dbContext = _contextFixture.CreateDbContext();

        var handler = new CreateCustomerCommandHandler(dbContext);

        var dto = new CustomerDetailDto()
        {
            FirstName = "Chia",
            LastName = "Karimi",
            Email = "Chia.Karimi@gmail.com"
        };

        var request = new CreateCustomerCommand(dto);


        // Act 
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        dbContext.Customers.Should().HaveCount(1);

        var customer = await dbContext.Customers.FirstOrDefaultAsync();

        customer?.FirstName.Should().Be("Chia");
        customer?.LastName.Should().Be("Karimi");
        customer?.Email.Value.Should().Be("Chia.Karimi@gmail.com");
    }
}