using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventoController : ControllerBase
    {
        //realizar o método de cadastrar (Post)

        private readonly ITiposEventoRepository _eventContext;

        public TiposEventoController()
        {
            _eventContext= new TiposEventoRepository();
        }

        /// <summary>
        /// Método para cadastrar um novo tipo de evento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposEvento tiposEvento)
        {
            try
            {
                _eventContext.CadastrarTipoEvento(tiposEvento);

                return StatusCode(201, "Objeto Cadastrado com sucesso");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para listar um tipo de evento 
        /// </summary>
        /// <returns>Tipos de eventos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventContext.ListarTiposEventos());
            }
            catch (Exception error)
            {
               return BadRequest (error.Message); 
            }
        }

        /// <summary>
        /// Método para deletar um novo tipo de evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status 204 - No Content</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventContext.Deletar(id);

                //if (_eventContext.Deletar == null)
                //{
                //    return BadRequest("O valor inserido é nulo ou já foi excluido enteriormente");
                //}

                return StatusCode(204, "Objeto Deletado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
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

        [HttpPut]
        public IActionResult Update(Guid id, TiposEvento tiposEvento)
        {
            try
            {
                _eventContext.Atualizar(id, tiposEvento);

                return Ok("usuario atualizado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
