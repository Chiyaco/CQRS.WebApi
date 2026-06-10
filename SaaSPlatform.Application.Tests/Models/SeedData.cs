using SaaSPlatform.Domain.Entities.Customer;
using SaaSPlatform.Infrastructure.Persistence;

namespace SaaSPlatform.Application.Tests.Models;

public static class SeedData
{
    public static async Task<Customer> CreateCustomerAsync(ApplicationDbContext dbContext)
    {
        var customer = new Customer("Chia", "Karimi", new Email("Chia.karimi@gmail.com"));

        dbContext.Customers.Add(customer);

        await dbContext.SaveChangesAsync();

        return customer;
    }
}