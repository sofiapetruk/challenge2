using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using challenge2.Models;

namespace Challenge2.Models
{
    public class Moto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMoto { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "O chassi deve conter exatamente 17 caracteres")]
        public string NmChassi { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "A placa deve ter no máximo 7 caracteres")]
        public string Placa { get; set; }

        [StringLength(100)]
        public string Unidade { get; set; }

        [Required]
        public int StatusMotoId { get; set; }

        public TipoStatus StatusMoto { get; set; }

        [Required]
        public int IdTipoMoto { get; set; }

        public TipoMoto TipoMoto { get; set; }

        public Moto() { }

        public Moto(int idMoto, string nmChassi, string placa, string unidade, int statusMotoId, int idTipoMoto)
        {
            IdMoto = idMoto;
            NmChassi = nmChassi;
            Placa = placa;
            Unidade = unidade;
            StatusMotoId = statusMotoId;
            IdTipoMoto = idTipoMoto;
        }
    }
}
