using CQRS.WebApi.Features.ProductFeatures.Queries;
using CQRS.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediatr.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediatr.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediatr.Send(new GetProductByIdQuery { Id = id });

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteProductByIdCommand { Id = id });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediatr.Send(command);

            return Ok();
        }
    }
}
