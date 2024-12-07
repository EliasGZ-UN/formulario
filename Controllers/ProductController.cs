using formulario.Entidades;
using formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                    .Include(p => p.Marca)
                    .Select(p => new ProductModel()
                     {
                        Id = p.Id,
                        Name = p.Nombre,
                        Quantity = p.Cantidad,
                        CreationDate = p.FechaCreacion,
                        Brand = new BrandModel()
                        {
                            Name = p.Marca.Nombre
                        }
                     })
                    .ToList();

            return View(list);
        }

        public IActionResult ProductAdd()
        {
            var model = new ProductModel();

            model.BrandList = _context.Marcas
                .Where(m => m.Activo)
                .Select(m => new SelectListItem()
                {
                    Value = m.Id.ToString(),
                    Text = m.Nombre
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductAdd", product);
            }
            
            var productEntity = new Producto();
            productEntity.Id = new Guid();
            productEntity.Nombre = product.Name;
            productEntity.Cantidad = product.Quantity;
            productEntity.FechaCreacion = product.CreationDate;
            productEntity.MarcaId = product.BrandId;

            this._context.Productos.Add(productEntity);
            this._context.SaveChanges();

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
            model.BrandId = producto.MarcaId;
            model.CreationDate = producto.FechaCreacion;
            
            model.BrandList = _context.Marcas
                .Where(m => m.Activo)
                .Select(m => new SelectListItem()
                {
                    Value = m.Id.ToString(),
                    Text = m.Nombre,
                    // Selected = m.Id == model.BrandId
                })
                .ToList();
            
            // var selected = model.BrandList.Where(m => m.Value == producto.MarcaId.ToString()).First();
            //     selected.Selected = true;

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
            producto.MarcaId = model.BrandId;

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

            return RedirectToAction("ProductList");
        }
    }
}
