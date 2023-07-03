using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Models.Interfaces.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMensagensController : ControllerBase
    {
        private readonly IRabbitMensagemService _service;

        public RabbitMensagensController(IRabbitMensagemService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Send(RabbitMensagem mensagem)
        {
            _service.Send(mensagem);
            return Ok();
        }
    }
}