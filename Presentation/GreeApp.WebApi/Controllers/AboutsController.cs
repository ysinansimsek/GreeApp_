using GreeApp.Application.Features.CQRS.Commands.AboutCommand;
using GreeApp.Application.Features.CQRS.Handlers.AboutHandler;
using GreeApp.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler ?? throw new ArgumentNullException(nameof(createAboutCommandHandler));
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler ?? throw new ArgumentNullException(nameof(getAboutByIdQueryHandler));
            _getAboutQueryHandler = getAboutQueryHandler ?? throw new ArgumentNullException(nameof(getAboutQueryHandler));
            _updateAboutCommandHandler = updateAboutCommandHandler ?? throw new ArgumentNullException(nameof(updateAboutCommandHandler));
            _removeAboutCommandHandler = removeAboutCommandHandler ?? throw new ArgumentNullException(nameof(removeAboutCommandHandler));
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("(id)")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout (int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
