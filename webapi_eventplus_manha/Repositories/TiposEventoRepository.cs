using Microsoft.EntityFrameworkCore;
using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TiposEvento tiposEvento)
        {
            TiposEvento eventoBuscado = _eventContext.TiposEvento.Find(id);

            if (eventoBuscado != null)
            {
                eventoBuscado.Titulo = tiposEvento.Titulo;
            }

            _eventContext.TiposEvento.Update(eventoBuscado!);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Método para retornar a partir de um ID um tipo de evento cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TiposEvento BuscarPorId(Guid id)
        {
            TiposEvento eventoBuscado = _eventContext.TiposEvento
                .Select(t => new TiposEvento
                {
                    IdTipoEvento = t.IdTipoEvento,
                    Titulo = t.Titulo

                }).FirstOrDefault(t => t.IdTipoEvento == id)!;

            return eventoBuscado;
        }

        /// <summary>
        /// Método para cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tiposEvento"></param>
        public void CadastrarTipoEvento(TiposEvento tiposEvento)
        {
            //para cadastrar um tipo de evento, precisamos apenas passar como parâmetro o .Add
            _eventContext.TiposEvento.Add(tiposEvento);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Método para deletar um evento cadastrado 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(Guid id)
        {
            TiposEvento deletarEvento = _eventContext.TiposEvento.Find(id)!;

            _eventContext.Remove(deletarEvento);

            _eventContext.SaveChanges();

            //Outra forma de remover o usuario
            //TiposUsuario usuarioRemovido = _eventContext.TiposUsuarios.Where(d => d.IdTipoUsuario == id).First();
            //_eventContext.Remove(usuarioRemovido);

            //_eventContext.SaveChanges();
        }

        /// <summary>
        /// Método para listar os tipos de evento existentes
        /// </summary>
        /// <returns>lista de tipos de ventos</returns>
        public List<TiposEvento> ListarTiposEventos()
        {
            return _eventContext.TiposEvento.ToList();
        }


    }
}
