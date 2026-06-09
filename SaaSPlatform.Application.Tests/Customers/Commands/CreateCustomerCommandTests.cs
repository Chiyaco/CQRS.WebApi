using Moq;
using SaaSPlatform.Application.Common.Interfaces;
using SaaSPlatform.Application.Features.Customers.Commands;
using SaaSPlatform.Application.Features.Customers.DTOs;

namespace SaaSPlatform.Application.Tests.Customers.Commands;


public class CreateCustomerCommandTests
{
    private readonly Mock<IApplicationDbContext> _dbContextMock;

    public CreateCustomerCommandTests()
    {
        _dbContextMock = new Mock<IApplicationDbContext>();
    }

    [Fact]
    public async Task Handle_Should_Create_Customer()
    {
        // Arrange 
        var customerDetailDto = new CustomerDetailDto
        {
            FirstName = "Chia",
            LastName = "Karimi",
            Email = new Domain.Entities.Customer.Email("chia.karimi@gmail.com")
        };

        var request = new CreateCustomerCommand(customerDetailDto);

        var handler = new CreateCustomerCommandHandler(_dbContextMock.Object);

        // Act 

        var result = handler.Handle(request, CancellationToken.None);
        // Assert

    }
}
