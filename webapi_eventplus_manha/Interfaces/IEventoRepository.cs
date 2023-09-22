using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Método que será criado para buscar um usuário por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Com o ID Buscado</returns>
        Evento BuscarPorId(Guid id);

        /// <summary>
        /// Método para realizar o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="tiposUsuario"></param>
        void CadastrarEvento(Evento evento);

        /// <summary>
        /// Listar todos os usuários criados
        /// </summary>
        /// <returns></returns>
        List<Evento> listarEventos();

        /// <summary>
        /// Método para realizar a atualização de um tipo de usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiposUsuario"></param>
        void Atualizar(Guid id, Evento evento);

        /// <summary>
        /// Método para deletar um tipo de usuário específico
        /// </summary>
        /// <param name="id"></param>
        void Deletar(Guid id);
    }
}
