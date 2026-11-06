using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TiendaApp.Models
{
    [Table("productos")]
    public class Producto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("idmarca")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una marca válida."), ]
        public int IdMarca { get; set; }

        [Column("descripcion")]
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(300)]
        public string Descripcion { get; set; } = "";

        [Column("precio", TypeName = "decimal(8,2)")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor a cero.")]
        public decimal Precio { get; set; }

        [Column("stock")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número positivo.")]
        public int Stock { get; set; }

        //Foreign Key
        [ForeignKey(nameof(IdMarca))]
        public Marca? Marca { get; set; }
    }
}
