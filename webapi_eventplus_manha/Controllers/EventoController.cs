using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Método para cadastrar um novo evento
        /// </summary>
        /// <param name="evento"></param>
        /// <returns> Valor cadastrado com sucesso!</returns>
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.CadastrarEvento(evento);

                return Ok("Objeto cadastrado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar a listagem dos eventos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.listarEventos());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar o delete de um evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content, evento deletado com sucesso</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return Ok("Objeto deletado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para atualizar um determinado evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns>Novo evento atualizado</returns>
        [HttpPut]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);

                return Ok("Objeto atualizado com sucesso");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método criado para buscar um evento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto Buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }


}
