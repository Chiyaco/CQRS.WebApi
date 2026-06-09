using Microsoft.EntityFrameworkCore;
using SaaSPlatform.Infrastructure.Persistence;

namespace SaaSPlatform.Application.Tests.Models;

public class DbContextFixture
{
    public ApplicationDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }
}

