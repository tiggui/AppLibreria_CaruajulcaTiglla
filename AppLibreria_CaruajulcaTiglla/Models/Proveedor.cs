using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AppLibreria_CaruajulcaTiglla.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RazonSocial { get; set; }

        public DateOnly FechaContrato { get; set; }

        [Required]
        public Valoracion Valoracion { get; set; }

        public virtual ICollection<MaterialEscritorio> MaterialEscritorios { get; set; }
    }

}
