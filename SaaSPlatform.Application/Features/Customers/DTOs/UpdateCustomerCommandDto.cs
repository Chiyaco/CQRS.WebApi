namespace SaaSPlatform.Application.Features.Customers.DTOs;

public class UpdateCustomerCommandDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;
}
