using GreeApp.Application.Features.CQRS.Commands.ProductCommand;
using GreeApp.Application.Features.CQRS.Handlers.ProductHandler;
using GreeApp.Application.Features.CQRS.Queries.ProductQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public ProductsController(CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductQueryHandler getProductQueryHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler)
        {
            _createProductCommandHandler = createProductCommandHandler ?? throw new ArgumentNullException(nameof(createProductCommandHandler));
            _getProductByIdQueryHandler = getProductByIdQueryHandler ?? throw new ArgumentNullException(nameof(getProductByIdQueryHandler));
            _getProductQueryHandler = getProductQueryHandler ?? throw new ArgumentNullException(nameof(getProductQueryHandler));
            _updateProductCommandHandler = updateProductCommandHandler ?? throw new ArgumentNullException(nameof(updateProductCommandHandler));
            _removeProductCommandHandler = removeProductCommandHandler ?? throw new ArgumentNullException(nameof(removeProductCommandHandler));
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct (int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
