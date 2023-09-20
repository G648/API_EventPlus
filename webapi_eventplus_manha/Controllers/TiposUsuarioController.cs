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

        /// <summary>
        /// Método para realizar o cadastro de um novo tipo de usuário 
        /// </summary>
        /// <param name="tiposUsuario"></param>
        /// <returns>Usuario cadastrado</returns>
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

        /// <summary>
        /// Realiza a listagem de todos os tipos de usuário
        /// </summary>
        /// <returns>Lista com todos os tipos de usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.ListarTiposUsuario());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// método para realizar o Delete de um tipo de usuário específico
        /// </summary>
        /// <returns>Tipo de Usuário deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                //retorno no content 204
                return StatusCode(204);
            }
            catch (Exception error)
            {
               return BadRequest(error.Message);
            }
        }
    }
}
