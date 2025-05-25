using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Challenge2.Models;

namespace challenge2.Models
{
    public class TipoStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStatus { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Status { get; set; }
        public DateTime Data { get; set; }

        public ICollection<Moto> Motos { get; set; }

        public TipoStatus() { }

        public TipoStatus(int idStatus, string status, DateTime data, ICollection<Moto> motos)
        {
            IdStatus = idStatus;
            Status = status;
            Data = data;
            Motos = motos;
        }
    }
}
