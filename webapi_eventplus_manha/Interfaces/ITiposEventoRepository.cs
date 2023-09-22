using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface ITiposEventoRepository 
    {
        /// <summary>
        /// Método que será criado para buscar um Evento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Evento Com o ID Buscado</returns>
        TiposEvento BuscarPorId(Guid id);

        /// <summary>
        /// Método para realizar o cadastro de um novo tipo de Evento
        /// </summary>
        /// <param name="TiposEvento"></param>
        void CadastrarTipoEvento(TiposEvento tiposEvento);

        /// <summary>
        /// Listar todos os usuários criados
        /// </summary>
        /// <returns></returns>
        List<TiposEvento> ListarTiposEventos();

        /// <summary>
        /// Método para realizar a atualização de um tipo de Evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiposUsuario"></param>
        void Atualizar(Guid id, TiposEvento tiposEvento);

        /// <summary>
        /// Método para deletar um tipo de Evento específico
        /// </summary>
        /// <param name="id"></param>
        void Deletar(Guid id);
    }
}

