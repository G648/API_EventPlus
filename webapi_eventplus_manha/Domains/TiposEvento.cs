using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table(nameof(TiposEvento))]
    public class TiposEvento
    {
        //vamos referenciar a chave primaria
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required (ErrorMessage = "Título do evento é obrigatório")]
        public string? Titulo { get; set; }
    }
}
