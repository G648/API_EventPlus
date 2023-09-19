using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table(nameof(PresencasEvento))]
    public class PresencasEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = ("Este campo é obrigatório"))]
        public bool Situacao { get; set; }

        //ref. tabela usuario = FK
        [Required(ErrorMessage = "O nome do campo IdUsuario é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref. tabela evento = FK
        [Required(ErrorMessage ="Evento Obrigatório")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }

}
