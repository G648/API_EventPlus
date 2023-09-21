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
            TiposUsuario usuarioBuscado = _eventContext.TiposUsuarios.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.TituloTipoUsuario = tiposUsuario.TituloTipoUsuario;
            }

            _eventContext.TiposUsuarios.Update(usuarioBuscado!);

            _eventContext.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
           
                TiposUsuario tiposUsuarioBuscado = _eventContext.TiposUsuarios
                    .Select(t => new TiposUsuario
                    {
                        IdTipoUsuario = t.IdTipoUsuario,
                        TituloTipoUsuario = t.TituloTipoUsuario

                    }).FirstOrDefault(t => t.IdTipoUsuario == id)!;

                return tiposUsuarioBuscado!;
        
        }

        public void CadastrarTipoUsuario(TiposUsuario tiposUsuario)
        {
            _eventContext.TiposUsuarios.Add(tiposUsuario);

            _eventContext.SaveChanges();    
        }

        public void Deletar(Guid id)
        {
            //_eventContext.TiposUsuarios.Remove(BuscarPorId(id));

            //_eventContext.SaveChanges();

            TiposUsuario usuarioRemovido = _eventContext.TiposUsuarios.Where(d => d.IdTipoUsuario == id).First();
            _eventContext.Remove(usuarioRemovido);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> ListarTiposUsuario()
        {
            return _eventContext.TiposUsuarios.ToList();
        }

    }
}
