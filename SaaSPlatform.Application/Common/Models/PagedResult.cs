using Microsoft.EntityFrameworkCore;

namespace SaaSPlatform.Application.Common.Models;

public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; } 

    public int PageNumber { get; }

    public int PageSize { get;}

    public int TotalCount { get; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalCount / PageSize);

    private PagedResult(
        IReadOnlyList<T> items,
        int totalCount,
        int pageSize,
        int pageNumber
        )
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static async Task<PagedResult<T>> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
    {
        var totalCount = await source.CountAsync(cancellationToken);

        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>(
            items,
            totalCount,
            pageNumber,
            pageSize);
    }
}