using System.ComponentModel.DataAnnotations;

namespace formulario.Entidades
{
    public class Caracteristica()
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set;}
        public string Descripcion { get; set;}
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
