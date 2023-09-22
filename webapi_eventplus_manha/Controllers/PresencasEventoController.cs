using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasEventoController : ControllerBase
    {
        private readonly IPresencaEventoRepository _eventContext;

        public PresencasEventoController()
        {
            _eventContext = new PresencaEventoRepository();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventContext.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult GetA(PresencasEvento presencasEvento)
        {
            try
            {
                _eventContext.CadastrarPresencaEvento(presencasEvento);

                return Ok();  
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
