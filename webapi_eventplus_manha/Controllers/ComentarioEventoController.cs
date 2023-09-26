using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentariosEventoRepository _comentariosEventoRepository;

        public ComentarioEventoController()
        {
            _comentariosEventoRepository = new ComentariosEventoRepository();
        }

        /// <summary>
        /// EndPoint para realizar o cadastro de um novo comentário
        /// </summary>
        /// <param name="comentariosEvento"></param>
        /// <returns>Comentário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(ComentariosEvento comentariosEvento)
        {
            try
            {
                _comentariosEventoRepository.CadastrarComentario(comentariosEvento);

                return Ok ("Comentário cadastrado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint para listar os comentários
        /// </summary>
        /// <returns>lista de comentários cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentariosEventoRepository.ListarComentarios());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint para realizar a busca de um determinado usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_comentariosEventoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// EndPoint para remover um comentário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comentário removido</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEventoRepository.DeletarComentario(id);

                return Ok("Comentário removido com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
