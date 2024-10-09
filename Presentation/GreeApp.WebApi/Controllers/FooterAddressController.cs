using GreeApp.Application.FooterAddresss.Mediator.Commands.FooterAddressCommands;
using GreeApp.Application.FooterAddresss.Mediator.Queries.FooterAddressQureies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreeApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresssController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddresssController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAddressById(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);  
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
