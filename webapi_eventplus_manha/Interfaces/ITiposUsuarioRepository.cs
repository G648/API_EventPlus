using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Método que será criado para buscar um usuário por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Com o ID Buscado</returns>
        TiposUsuario BuscarPorId(Guid id);

        /// <summary>
        /// Método para realizar o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="tiposUsuario"></param>
        void CadastrarTipoUsuario(TiposUsuario tiposUsuario);

        /// <summary>
        /// Listar todos os usuários criados
        /// </summary>
        /// <returns></returns>
        List<TiposUsuario> ListarTiposUsuario();

        /// <summary>
        /// Método para realizar a atualização de um tipo de usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiposUsuario"></param>
        void Atualizar(Guid id, TiposUsuario tiposUsuario);

        /// <summary>
        /// Método para deletar um tipo de usuário específico
        /// </summary>
        /// <param name="id"></param>
        void Deletar(Guid id);
    }
}
