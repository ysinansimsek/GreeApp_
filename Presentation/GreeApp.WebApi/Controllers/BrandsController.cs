using GreeApp.Application.Features.CQRS.Commands.BrandCommand;
using GreeApp.Application.Features.CQRS.Handlers.BrandHandler;
using GreeApp.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler ?? throw new ArgumentNullException(nameof(createBrandCommandHandler));
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler ?? throw new ArgumentNullException(nameof(getBrandByIdQueryHandler));
            _getBrandQueryHandler = getBrandQueryHandler ?? throw new ArgumentNullException(nameof(getBrandQueryHandler));
            _updateBrandCommandHandler = updateBrandCommandHandler ?? throw new ArgumentNullException(nameof(updateBrandCommandHandler));
            _removeBrandCommandHandler = removeBrandCommandHandler ?? throw new ArgumentNullException(nameof(removeBrandCommandHandler));
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand (int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
