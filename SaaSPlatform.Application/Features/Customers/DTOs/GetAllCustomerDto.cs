
namespace SaaSPlatform.Application.Features.Customers.DTOs;

public class GetAllCustomerDto
{
    public IReadOnlyList<CustomerDetailDto>? Customers { get; }
}
