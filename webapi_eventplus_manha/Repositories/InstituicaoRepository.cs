using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class InstituicaoRepository :IInstituicaoRepository
    {

        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext= new EventContext();
        }

        /// <summary>
        /// cadastra nova instituição
        /// </summary>
        /// <param name="instituicao"></param>
        public void CadastrarInstituicao(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);

            _eventContext.SaveChanges();
        }
    }
}
