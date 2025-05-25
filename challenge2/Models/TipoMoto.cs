using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge2.Models
{
    public class TipoMoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "O nome do tipo é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do tipo deve ter no máximo 100 caracteres")]
        public string NmTipo { get; set; }

        public ICollection<Moto> Motos { get; set; }


        public TipoMoto() { }

        public TipoMoto(int idTipo, string nmTipo, ICollection<Moto> motos)
        {
            IdTipo = idTipo;
            NmTipo = nmTipo;
            Motos = motos;
        }
    }
}
