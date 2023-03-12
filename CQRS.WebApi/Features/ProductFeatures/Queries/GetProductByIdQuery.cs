using CQRS.WebApi.Data;
using CQRS.WebApi.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS.WebApi.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IProductDbContext _context;


            public GetProductByIdQueryHandler(IProductDbContext dbContext)
            {
                _context = dbContext;
            }

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(a => a.Id == request.Id);

                if (product is not null)
                    return product;

                return null;
            }
        }
    }
}
