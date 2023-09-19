using Microsoft.AspNetCore.Http.HttpResults;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository

    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TiposUsuario tiposUsuario)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarTipoUsuario(TiposUsuario tiposUsuario)
        {
            _eventContext.TiposUsuarios.Add(tiposUsuario);

            _eventContext.SaveChanges();    
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> ListarTiposUsuario()
        {
            throw new NotImplementedException();
        }

    }
}
