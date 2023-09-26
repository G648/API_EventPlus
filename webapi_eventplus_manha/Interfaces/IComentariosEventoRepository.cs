using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface IComentariosEventoRepository
    {
        /// <summary>
        /// Método para cadastrar um novo comentário
        /// </summary>
        /// <param name="comentariosEvento"></param>
        public void CadastrarComentario(ComentariosEvento comentariosEvento);

        /// <summary>
        /// Método para listar os comentários de eventos
        /// </summary>
        /// <returns>Lista de comentários</returns>
        List<ComentariosEvento> ListarComentarios();

        /// <summary>
        /// Método para listar um comentário específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Comentário buscado</returns>
        ComentariosEvento BuscarPorId(Guid id);

        /// <summary>
        /// Método para remover um comentário cadastrado
        /// </summary>
        public void DeletarComentario(Guid id);
    }
}
