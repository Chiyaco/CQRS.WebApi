using SaaSPlatform.Domain.Entities.Customer;

namespace SaaSPlatform.Application.Features.Customers.DTOs;

public class CustomerDetailDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Email? Email { get; set; }
}