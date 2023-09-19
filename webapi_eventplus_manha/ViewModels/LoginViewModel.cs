using System.ComponentModel.DataAnnotations;

namespace webapi_eventplus_manha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Nome do campo é obrigatório")]
        public string? EmailUser { get; set; }


        [Required(ErrorMessage = "O Nome do campo é obrigatório")]
        public string? Senhauser { get; set; }

    }
}
