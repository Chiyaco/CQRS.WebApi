using Microsoft.EntityFrameworkCore;
using SaaSPlatform.Domain.Entities.Customer;
using SaaSPlatform.Domain.Entities.Order;
using SaaSPlatform.Domain.Entities.Product;

namespace SaaSPlatform.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get;}
    DbSet<Order> Orders { get;}
    DbSet<Product> Products { get;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}