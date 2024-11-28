using System.ComponentModel.DataAnnotations;

namespace formulario.Entidades
{
    public class Marca()
    {
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Producto>? Productos { get; set; }
    }
}
