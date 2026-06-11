using FluentAssertions;
using SaaSPlatform.Application.Features.Customers.Queries;
using SaaSPlatform.Application.Tests.Models;
using SaaSPlatform.Domain.Entities.Customer;
using SaaSPlatform.Infrastructure.Persistence;

namespace SaaSPlatform.Application.Tests.Customers.Queries;

public class GetCustomerQueriesTests
{
    private readonly DbContextFixture _contextFixture = new();

    [Fact]
    public async Task GetCustomerQueryById_Should_Throw_When_CustomerId_Is_Empty()
    {
        // Arrange 

        await using var dbContext = _contextFixture.CreateDbContext();
        var query = new GetCustomerByIdQuery(Guid.Empty);
        var queryHandler = new GetCustomerByIdQueryHandler(dbContext);

        // Act 

        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be("The customer Id should nopt be null!");
    }

    [Fact]
    public async Task GetCustomerQueryById_Should_Return_Failure_When_Not_Found()
    {
        // Arrange

        await using var dbContext = _contextFixture.CreateDbContext();
        var query = new GetCustomerByIdQuery(Guid.NewGuid());
        var handler = new GetCustomerByIdQueryHandler(dbContext);


        // Act 
        var result = handler.Handle(query, CancellationToken.None);

        // Assert

        result.Should().NotBeNull();
        result.Result.Should().NotBeNull();
        result.Result.IsSuccess.Should().BeFalse();
        result.Result.Error.Should().Be("The customer didn't find!");
    }

    [Fact]
    public async Task GetCustomerById_Should_Not_Return_Null_Customer_When_Customer_Exists()
    {
        // Arrange 

        await using var dbContext = _contextFixture.CreateDbContext();

        var existedCustomer = await SeedData.CreateRowDataAsync<Customer>(dbContext,
            () => new Customer(
                "Chia",
                "Karimi",
                new Email("Chia.karimi@gmail.com")));

        var query = new GetCustomerByIdQuery(existedCustomer.Id);
        var queryHandler = new GetCustomerByIdQueryHandler(dbContext);

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);


        // Assert

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();

        result.Value.Should().NotBeNull();
        result.Value!.FirstName.Should().Be("Chia");
        result.Value!.LastName.Should().Be("Karimi");
        result.Value!.Email.Should().Be("Chia.karimi@gmail.com");
    }

    [Fact]
    public async Task GetAllCustomerQuery_Should_Return_Customers()
    {
        // Arrange 

        await using var dbContext = _contextFixture.CreateDbContext();

        await SeedData.CreateRowDataAsync<Customer>(dbContext,
            () => new Customer(
                "Chia",
                "Karimi",
                new Email("Chia.karimi@gmail.com")));

        var query = new GetAllCustomerQuery();
        var queryHandler = new GetAllCustomerQueryHandler(dbContext);

        // Act 

        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert

        result.Should().NotBeNull();

        result.IsSuccess.Should().BeTrue();

        result.Value.Should().NotBeNull();

        result.Value.TotalCount.Should().Be(1);
    }
}