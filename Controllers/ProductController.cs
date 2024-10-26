using formulario.Entidades;
using formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace formulario.Controllers
{
    public class ProductController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            List<ProductModel> list =
                _context.Productos
                    .Select(p => new ProductModel()
                     {
                        Id = p.Id,
                        Name = p.Nombre,
                        Quantity = p.Cantidad,
                        CreationDate = p.FechaCreacion
                     })
                    .ToList();

            return View(list);
        }

        public IActionResult ProductAdd()
        {
            var model = new ProductModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel product)
        {
            var productEntity = new Producto();
            productEntity.Id = product.Id;
            productEntity.Nombre = product.Name;
            productEntity.Cantidad = product.Quantity;
            productEntity.FechaCreacion = product.CreationDate;

            this._context.Productos.Add(productEntity);
            await this._context.SaveChangesAsync();

            return RedirectToAction("ProductList", "Product");
        }

        public IActionResult ProductEdit(Guid Id)
        {
            var producto = _context.Productos
                .Where(p => p.Id == Id).FirstOrDefault();

            if (producto == null)
            {
                return NotFound();
            }

            ProductModel model = new ProductModel();
            model.Id = producto.Id;
            model.Name = producto.Nombre;
            model.Quantity = producto.Cantidad;
            model.CreationDate = producto.FechaCreacion;

            return View(model);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductModel model)
        {
            var producto = _context.Productos
                .Where(p => p.Id == model.Id).FirstOrDefault();
                
            if (producto == null)
            {
                return NotFound();
            }

            producto.Nombre = model.Name;
            producto.Cantidad = model.Quantity;
            producto.FechaCreacion = model.CreationDate;

            _context.Productos.Update(producto);
            _context.SaveChanges();

            return RedirectToAction("ProductList", "Product");
        }

        public IActionResult ProductDelete(Guid Id)
        {
            var producto = _context.Productos
                .Where(p => p.Id == Id).FirstOrDefault();

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("ProductList", "Product");
        }
    }
}
