using Microsoft.EntityFrameworkCore;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            PresencasEvento atualizarPresenca =  _eventContext.PresencasEvento.Find(id, presencasEvento)!;

            _eventContext.Update(atualizarPresenca);

            _eventContext.SaveChanges();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            PresencasEvento presencaEncontrada = _eventContext.PresencasEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;

            if (presencaEncontrada == null)
            {
                throw new Exception($"Usuario {id} não encontrado no sistema!");
            }

            return presencaEncontrada;
        }

        public void CadastrarPresencaEvento(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> listarPresencaEvento()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> presencaEventoUser(Guid IdUsuario)
        {
            return _eventContext.PresencasEvento.Where(p => p.IdUsuario == IdUsuario).Include(p => p.Usuario).Include(p => p.Evento).ToList();
        }

        public void Deletar(Guid id)
        {
            PresencasEvento deleteById = _eventContext.PresencasEvento.Find(id);

            _eventContext.Remove(deleteById);

            _eventContext.SaveChanges();
        }
    }
}
