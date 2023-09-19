using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario"></param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Método para buscar um usuário por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Buscado com ID</returns>
        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Método para retornar o usuario através do email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
