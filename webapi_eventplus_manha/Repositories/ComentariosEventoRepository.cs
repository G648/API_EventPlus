using webapi_eventplus_manha.Contexts;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;

namespace webapi_eventplus_manha.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {

        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor da nossa classe de conexão com o banco de dados
        /// </summary>
        public ComentariosEventoRepository()
        {
            _eventContext = new EventContext(); 
        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
            ComentariosEvento buscarPorId =  _eventContext.ComentariosEvento.FirstOrDefault(c => c.IdComentarioEvento.Equals(id))!;

            if (buscarPorId == null)
            {
                throw new Exception($"o comentário do id {id} não foi encontrado");
            }

            return buscarPorId;
        }

        public void CadastrarComentario(ComentariosEvento comentariosEvento)
        {
            _eventContext.ComentariosEvento.Add(comentariosEvento);

            _eventContext.SaveChanges();
        }

        public void DeletarComentario(Guid id)
        {
            ComentariosEvento deletarComentario = _eventContext.ComentariosEvento.FirstOrDefault(c => c.IdComentarioEvento == id)!;

            _eventContext.Remove(deletarComentario);

            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> ListarComentarios()
        {
           return _eventContext.ComentariosEvento.ToList();
        }
    }
}
