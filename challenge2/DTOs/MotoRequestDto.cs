using System.ComponentModel.DataAnnotations;

namespace Challenge2.Dtos
{
    public class MotoRequestDto
    {
        [Required(ErrorMessage = "O número do chassi é obrigatório")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "O chassi deve conter exatamente 17 caracteres")]
        public string NmChassi { get; set; }

        [Required(ErrorMessage = "A placa é obrigatória")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve conter exatamente 7 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A unidade é obrigatória")]
        public string Unidade { get; set; }
    }
}
