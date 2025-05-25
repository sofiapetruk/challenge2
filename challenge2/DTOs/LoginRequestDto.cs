using System.ComponentModel.DataAnnotations;

namespace Challenge2.Dtos
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 15 caracteres")]
        public string Senha { get; set; }
    }
}
