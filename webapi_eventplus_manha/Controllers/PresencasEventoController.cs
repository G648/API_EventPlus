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

        /// <summary>
        /// Método para realizar um cadastro de uma nova presença para um determinado evento
        /// </summary>
        /// <param name="presencasEvento"></param>
        /// <returns>Presença cadastrada</returns>
        [HttpPost]
        public IActionResult Post(PresencasEvento presencasEvento)
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

        /// <summary>
        /// Método para buscar uma presença de evento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Presença de evento buscada</returns>
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

        /// <summary>
        /// Método para buscar todos os eventos vinculados a um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>presenças de um usuario em um determinado evento</returns>
        [HttpGet("{idUser}")]
        public IActionResult Get(Guid id) 
        { 
            return Ok(_eventContext.presencaEventoUser(id));
        }

        /// <summary>
        /// Método para realizar a listagem de todas as presenças de eventos
        /// </summary>
        /// <returns>Lista com presença de eventos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventContext.listarPresencaEvento());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para realizar atualização do evento cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presencasEvento"></param>
        /// <returns>Objeto atualizado</returns>
        [HttpPut]
        public IActionResult Put(Guid id, PresencasEvento presencasEvento)
        {
            try
            {
                _eventContext.Atualizar(id, presencasEvento);

                return Ok("Objeto Atualizado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// método para realizar o delete de uma presença de evento específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventContext.Deletar(id);

                return Ok("Conteúdo excluido com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
