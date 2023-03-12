using CQRS.WebApi.Data;
using CQRS.WebApi.Models;
using MediatR;


namespace CQRS.WebApi.Features.ProductFeatures.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly IProductDbContext _context;


    public UpdateProductCommandHandler(IProductDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(a => a.Id == request.Id);

        if (product == null)
        {
            return default;
        }
        else
        {
            product.Barcode = request.Barcode;

            product.Name = request.Name;

            product.BuyingPrice = request.BuyingPrice;

            product.Rate = request.Rate;

            product.Description = request.Description;

            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
