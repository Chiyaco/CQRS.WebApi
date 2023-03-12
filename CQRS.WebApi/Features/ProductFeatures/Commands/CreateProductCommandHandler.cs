using CQRS.WebApi.Data;
using CQRS.WebApi.Entity;
using CQRS.WebApi.Models;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.WebApi.Features.ProductFeatures.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductDbContext _context;

        public CreateProductCommandHandler(IProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Barcode = request.Barcode;
            product.Name = request.Name;
            product.BuyingPrice = request.BuyingPrice;
            product.Rate = request.Rate;
            product.Description = request.Description;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
