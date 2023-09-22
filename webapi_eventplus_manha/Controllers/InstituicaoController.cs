using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.CadastrarInstituicao(instituicao);

                return Ok("Objeto cadastrado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
