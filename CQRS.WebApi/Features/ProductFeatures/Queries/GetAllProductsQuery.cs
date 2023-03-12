using CQRS.WebApi.Data;
using CQRS.WebApi.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebApi.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IProductDbContext _productDbContext;

            public GetAllProductQueryHandler(IProductDbContext productDbContext)
            {
                _productDbContext = productDbContext;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var productList = await _productDbContext.Products.ToListAsync(cancellationToken: cancellationToken);

                if (productList != null)
                    return productList.AsReadOnly();

                return null;
            }
        }
    }
}
