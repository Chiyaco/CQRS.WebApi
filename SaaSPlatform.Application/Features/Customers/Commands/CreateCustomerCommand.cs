using MediatR;
using Microsoft.EntityFrameworkCore;
using SaaSPlatform.Application.Common.Interfaces;
using SaaSPlatform.Application.Common.Models;
using SaaSPlatform.Application.Features.Customers.DTOs;
using SaaSPlatform.Domain.Entities.Customer;

namespace SaaSPlatform.Application.Features.Customers.Commands;

public record CreateCustomerCommand(CustomerDetailDto CustomerDetailDto) : IRequest<Result>;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result>
{
    private readonly IApplicationDbContext? _dbContext;

    public CreateCustomerCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customerDetailDto = request.CustomerDetailDto;

            var existedCustomer =
                await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == customerDetailDto.Email);

            if (existedCustomer is not null)
                return Result.Failure($"The user existed currently with this email address: {customerDetailDto.Email}");

            var customer =
                new Customer(customerDetailDto.FirstName,
                    customerDetailDto.LastName,
                    customerDetailDto.Email);

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}