namespace SaaSPlatform.Application.Features.Customers.DTOs;

public class UpdateCustomerEmailAddressCommandDto
{
    public Guid Id { get; set; }

    public string EmailAddress { get; set; } = string.Empty;
}