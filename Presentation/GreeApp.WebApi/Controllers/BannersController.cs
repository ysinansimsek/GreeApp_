using GreeApp.Application.Features.CQRS.Commands.BannerCommand;
using GreeApp.Application.Features.CQRS.Handlers.BannerHandler;
using GreeApp.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler ?? throw new ArgumentNullException(nameof(createBannerCommandHandler));
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler ?? throw new ArgumentNullException(nameof(getBannerByIdQueryHandler));
            _getBannerQueryHandler = getBannerQueryHandler ?? throw new ArgumentNullException(nameof(getBannerQueryHandler));
            _updateBannerCommandHandler = updateBannerCommandHandler ?? throw new ArgumentNullException(nameof(updateBannerCommandHandler));
            _removeBannerCommandHandler = removeBannerCommandHandler ?? throw new ArgumentNullException(nameof(removeBannerCommandHandler));
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner (int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
