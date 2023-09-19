using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private readonly ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.CadastrarTipoUsuario(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet] 
        public IActionResult Get() 
        {
            try
            {
                _tiposUsuarioRepository.ListarTiposUsuario();

                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
