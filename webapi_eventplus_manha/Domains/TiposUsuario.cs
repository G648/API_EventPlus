using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table (nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "O nome do campo é obrigatório!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
