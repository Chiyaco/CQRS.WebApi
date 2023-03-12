using CQRS.WebApi.Data;
using CQRS.WebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.WebApi.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
    {
        private readonly IProductDbContext _context;

        public DeleteProductByIdCommandHandler(IProductDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            if (product == null) return default;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
