using GreeApp.Application.Features.CQRS.Commands.ItemProductCommand;
using GreeApp.Application.Features.CQRS.Handlers.ItemProductHandler;
using GreeApp.Application.Features.CQRS.Queries.ItemProductQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProductsController : ControllerBase
    {
        private readonly CreateItemProductCommandHandler _createItemProductCommandHandler;
        private readonly GetItemProductByIdQueryHandler _getItemProductByIdQueryHandler;
        private readonly GetItemProductQueryHandler _getItemProductQueryHandler;
        private readonly UpdateItemProductCommandHandler _updateItemProductCommandHandler;
        private readonly RemoveItemProductCommandHandler _removeItemProductCommandHandler;

        public ItemProductsController(CreateItemProductCommandHandler createItemProductCommandHandler, GetItemProductByIdQueryHandler getItemProductByIdQueryHandler, GetItemProductQueryHandler getItemProductQueryHandler, UpdateItemProductCommandHandler updateItemProductCommandHandler, RemoveItemProductCommandHandler removeItemProductCommandHandler)
        {
            _createItemProductCommandHandler = createItemProductCommandHandler ?? throw new ArgumentNullException(nameof(createItemProductCommandHandler));
            _getItemProductByIdQueryHandler = getItemProductByIdQueryHandler ?? throw new ArgumentNullException(nameof(getItemProductByIdQueryHandler));
            _getItemProductQueryHandler = getItemProductQueryHandler ?? throw new ArgumentNullException(nameof(getItemProductQueryHandler));
            _updateItemProductCommandHandler = updateItemProductCommandHandler ?? throw new ArgumentNullException(nameof(updateItemProductCommandHandler));
            _removeItemProductCommandHandler = removeItemProductCommandHandler ?? throw new ArgumentNullException(nameof(removeItemProductCommandHandler));
        }

        [HttpGet]
        public async Task<IActionResult> ItemProductList()
        {
            var values = await _getItemProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetItemProduct(int id)
        {
            var value = await _getItemProductByIdQueryHandler.Handle(new GetItemProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemProduct(CreateItemProductCommand command)
        {
            await _createItemProductCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemProduct (int id)
        {
            await _removeItemProductCommandHandler.Handle(new RemoveItemProductCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItemProduct(UpdateItemProductCommand command)
        {
            await _updateItemProductCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
