using Microsoft.AspNetCore.Http.HttpResults;
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
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.TiposEvento = evento.TiposEvento;
                eventoBuscado.Instituicao = evento.Instituicao;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.DescricaoEvento = evento.DescricaoEvento;

                if (evento.IdTipoEvento != Guid.Empty)
                {
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }

                if (evento.IdInstituicao != Guid.Empty)
                {
                    eventoBuscado.IdInstituicao = evento.IdInstituicao;
                }
            }

            _eventContext.Evento.Update(eventoBuscado!);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            Evento eventosBuscados = _eventContext.Evento
                .Select(e => new Evento
                {
                    IdTipoEvento = e.IdTipoEvento,
                    IdInstituicao = e.IdInstituicao,
                    IdEvento = e.IdEvento,
                    DataEvento = e.DataEvento,
                    NomeEvento = e.NomeEvento,
                    DescricaoEvento = e.DescricaoEvento,
                    TiposEvento = e.TiposEvento,
                    Instituicao = e.Instituicao,

                }).FirstOrDefault(e => e.IdEvento == id)!;

            return eventosBuscados;
        }

        /// <summary>
        /// Método criar para cadastrar um evento 
        /// </summary>
        /// <param name="evento"></param>
        public void CadastrarEvento(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            _eventContext.Evento.Remove(eventoBuscado);

            if (eventoBuscado == null)
            {
                throw new Exception($"O evento {id} não foi encontrado em nosso sistema!");
            }

            _eventContext.SaveChanges();
        }

        public List<Evento> listarEventos()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
