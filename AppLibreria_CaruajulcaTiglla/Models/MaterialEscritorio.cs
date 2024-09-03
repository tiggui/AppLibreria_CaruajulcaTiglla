using System.ComponentModel.DataAnnotations;

namespace AppLibreria_CaruajulcaTiglla.Models
{
    public class MaterialEscritorio
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ProveedorId { get; set; } // Clave foránea
        public virtual Proveedor Proveedor { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }


    }
}
