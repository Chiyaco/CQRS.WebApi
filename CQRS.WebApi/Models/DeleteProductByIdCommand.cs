using MediatR;

namespace CQRS.WebApi.Models
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
