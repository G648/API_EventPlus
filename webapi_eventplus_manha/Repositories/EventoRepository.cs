using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarEvento(Evento evento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> listarEventos()
        {
            throw new NotImplementedException();
        }
    }
}
