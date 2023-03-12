using CQRS.WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebApi.Data;

public interface IProductDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Product> Products { get; set; }
}