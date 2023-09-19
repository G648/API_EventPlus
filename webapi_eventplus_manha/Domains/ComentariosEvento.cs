using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table(nameof(ComentariosEvento))]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome do campo Descrição é obrigatório")]
        [Column(TypeName = "TEXT")]
        public string? DescricaoEvento { get; set; }

        [Required(ErrorMessage = "A informação exibida é obrigatória")]
        [Column(TypeName = "BIT")]
        public bool Exibe { get; set; }

        //ref. tabela evento = FK
        [Required(ErrorMessage = "Evento Obrigatório")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
