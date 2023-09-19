using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_eventplus_manha.Domains
{
    [Table(nameof(Usuario))]
    //especificando que o campo email é único
    [Index(nameof(EmailUser), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Required (ErrorMessage ="O nome do campo é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeUsuario { get; set; }


        [DisplayName("Email Usuario")]
        [Required (ErrorMessage ="O nome do campo Email é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? EmailUser { get; set; }


        [DisplayName("Senha Usuario")]
        [Required (ErrorMessage ="O nome do campo Senha é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(60,MinimumLength = 5, ErrorMessage ="O nome do campo deve conter entre 0 e 20 caracteres")]
        public string? SenhaUser { get; set; }


        //ref.tablea TiposUsuario = FK
        [Required(ErrorMessage = "Informe o tipo do usuário")]
        public Guid IdTipoUsuario { get; set; }


        //ideal o nameof para quando vamos reutilizar nossas variáveis
        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
