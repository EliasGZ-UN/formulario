using Microsoft.AspNetCore.Mvc;

namespace formulario.Models
{
    public class ProductModel
    {
        public ProductModel()
        {}

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}