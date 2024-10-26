using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formulario.Models
{
    public class CaracteristicaModel
    {
        public CaracteristicaModel()
        {}

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; }
        public List<SelectListItem>? ListaProductos { get; set; }
    }
}