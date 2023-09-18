using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeInstituicao { get; set; }

        [Required (ErrorMessage = "O nome do campo é obrigatório")]
        [Column(TypeName = "CHAR(14)")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "O nome do campo é obrigatório")]
        [Column(TypeName = "VARCHAR(255)")]
        public string? EnderecoInstituicao { get; set; }
    }
}
