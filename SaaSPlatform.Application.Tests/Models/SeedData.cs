using SaaSPlatform.Domain.Entities.Customer;
using SaaSPlatform.Infrastructure.Persistence;

namespace SaaSPlatform.Application.Tests.Models;

public static class SeedData
{
    public static async Task<T> CreateRowDataAsync<T>(ApplicationDbContext dbContext, Func<T> factory)
        where T : class
    {
        var entity = factory();

        dbContext.Set<T>().Add(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public static async Task CreateListRowDataAsync<T>(
        ApplicationDbContext dbContext,
        int count,
        Func<int, T> factory)
        where T : class
    {
        var entities = Enumerable.Range(1, count)
            .Select(factory)
            .ToList();

        dbContext.Set<T>().AddRange(entities);

        await dbContext.SaveChangesAsync();
    }
}