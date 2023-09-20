using Microsoft.AspNetCore.Http.HttpResults;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Utils;

namespace webapi_eventplus_manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscadoEmail = _eventContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         NomeUsuario = u.NomeUsuario,
                         EmailUser = u.EmailUser,
                         SenhaUser = u.SenhaUser,

                         TiposUsuario = new TiposUsuario
                         {
                             TituloTipoUsuario = u.TiposUsuario!.TituloTipoUsuario
                         }
                     }).FirstOrDefault(u => u.EmailUser == email)!;

                if (usuarioBuscadoEmail != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscadoEmail.SenhaUser!);

                    if (confere)
                    {
                        return usuarioBuscadoEmail;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            //criando uma busca personalizada
            try
            {
                
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,

                        TiposUsuario = new TiposUsuario
                        {
                            TituloTipoUsuario = u.TiposUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                //primeiro criptografar a senha cadastrada
                usuario.SenhaUser = Criptografia.GerarHash(usuario.SenhaUser!);

                //adicionar o usuario
                _eventContext.Usuario.Add(usuario);

                //salvar as alterações
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                //return BadRequest(error.Message);
                throw;
            }
        }
    }
}
