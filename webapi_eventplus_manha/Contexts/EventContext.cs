using Microsoft.EntityFrameworkCore;
using webapi_eventplus_manha.Domains;

namespace webapi_eventplus_manha.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        //vamos definir a nossa configuração de string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=NOTE16-S15; Database=webapi_eventplus_manha; user id= sa; Pwd=Senai@134; TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Server=AMORIM\\SQLEXPRESS; Database=webapi_eventplus_manha; user id= sa; Pwd=Senai@134; TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
