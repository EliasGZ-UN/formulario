using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using formulario.Validaciones;

namespace formulario.Models
{
    public class ProductModel
    {
        public ProductModel()
        {}

        public Guid Id { get; set; }

        //Anotaciones para el campo Name
        [Required(ErrorMessage = "Falta el dato {0}")]
        [StringLength(maximumLength: 250, MinimumLength = 4,
            ErrorMessage = "La longitud del {0} debe ser entre mínimo {2} y máximo {1} caracteres.")]
        [Display(Name = "Nombre del Producto")]
        [EmpezarMayus]
        public string Name { get; set; }

        [Required(ErrorMessage = "Falta el dato {0}")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}