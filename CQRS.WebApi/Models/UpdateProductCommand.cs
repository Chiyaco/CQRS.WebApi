using MediatR;

namespace CQRS.WebApi.Models
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal BuyingPrice { get; set; }

        public decimal Rate { get; set; }
    }
}
