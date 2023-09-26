using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Método para cadastrar uma nova instituição
        /// </summary>
        /// <param name="presencasEvento"></param>
        void CadastrarInstituicao(Instituicao instituicao);

        List<Instituicao> ListarInstituicao();
    }
}
