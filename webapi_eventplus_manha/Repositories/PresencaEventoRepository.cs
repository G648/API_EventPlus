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
            _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            throw new NotImplementedException();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            PresencasEvento presencaEncontrada =  _eventContext.PresencasEvento.Find(id);

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

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PresencasEvento> listarPresencaEvento()
        {
            throw new NotImplementedException();
        }

        public List<PresencasEvento> presencaEventoUser(Guid IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
