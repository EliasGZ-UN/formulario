using System.ComponentModel.DataAnnotations;

namespace formulario.Entidades
{
    public class Producto()
    {
        public Guid Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Nombre { get; set;}
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Caracteristica>? Caracteristicas { get; set; }
    }
}
