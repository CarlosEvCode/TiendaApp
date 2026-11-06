using System.ComponentModel.DataAnnotations.Schema; //Esquema Tabla
namespace TiendaApp.Models
{
    [Table("marcas")]
    public class Marca
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("marca")]
        public string Nombre { get; set; } = "";
    }
}
