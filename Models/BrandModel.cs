using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using formulario.Validaciones;

namespace formulario.Models
{
    public class BrandModel()
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Falta el dato {0}")]
        [StringLength(maximumLength: 250, MinimumLength = 4,
            ErrorMessage = "La longitud del {0} debe ser entre mínimo {2} y máximo {1} caracteres.")]
        [Display(Name = "Nombre de la Marca")]
        [EmpezarMayus]
        public string Name { get; set;}
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
