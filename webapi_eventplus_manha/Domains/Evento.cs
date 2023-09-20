using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace webapi_eventplus_manha.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome do campo é obrigatório")]
        [Column(TypeName ="DATE")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage ="O nome do campo é obrigatório")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeEvento { get; set; }

        [Required(ErrorMessage ="O nome do campo é obrigatório")]
        [Column(TypeName = "TEXT")]
        public string? DescricaoEvento { get; set; }

        //ref. tabela TiposUsuario = FK

        [Required (ErrorMessage = "O tipo do evento é obrigatório")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        //ref. tabela Instituicao = FK

        [Required(ErrorMessage = "O nome do campo IdInstituicao é obrigatório")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
