using formulario.Entidades;
using formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace formulario.Controllers
{
    public class BrandController : Controller
    {
        public readonly ApplicationDbContext _context;

        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult BrandList()
        {
            List<BrandModel> list =
                _context.Marcas
                    .Select(p => new BrandModel()
                     {
                        Id = p.Id,
                        Name = p.Nombre,
                        Description = p.Descripcion,
                        Active = p.Activo,
                        CreationDate = p.FechaCreacion
                     })
                    .ToList();

            return View(list);
        }

        public IActionResult BrandAdd()
        {
            var model = new BrandModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BrandAdd(BrandModel brand)
        {
            if (!ModelState.IsValid)
            {
                return View("BrandAdd", brand);
            }
            
            var brandEntity = new Marca();
            brandEntity.Id = new Guid();
            brandEntity.Nombre = brand.Name;
            brandEntity.Descripcion = brand.Description;
            brandEntity.Activo = brand.Active;
            brandEntity.FechaCreacion = DateTime.Now;

            this._context.Marcas.Add(brandEntity);
            this._context.SaveChanges();

            return RedirectToAction("BrandList", "Brand");
        }

        public IActionResult BrandEdit(Guid Id)
        {
            var marca = _context.Marcas
                .Where(p => p.Id == Id).FirstOrDefault();

            if (marca == null)
            {
                return NotFound();
            }

            BrandModel model = new BrandModel();
            model.Id = marca.Id;
            model.Name = marca.Nombre;
            model.Description = marca.Descripcion;
            model.Active = marca.Activo;
            model.CreationDate = marca.FechaCreacion;

            return View(model);
        }

        [HttpPost]
        public IActionResult BrandEdit(BrandModel model)
        {
            var marca = _context.Marcas
                .Where(p => p.Id == model.Id).FirstOrDefault();
                
            if (marca == null)
            {
                return NotFound();
            }

            marca.Nombre = model.Name;
            marca.Descripcion = model.Description;
            marca.Activo = model.Active;
            marca.FechaCreacion = model.CreationDate;

            _context.Marcas.Update(marca);
            _context.SaveChanges();

            return RedirectToAction("BrandList", "Brand");
        }

        public IActionResult BrandDelete(Guid Id)
        {
            var marca = _context.Marcas
                .Where(p => p.Id == Id).FirstOrDefault();

            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            _context.SaveChanges();

            return RedirectToAction("BrandList");
        }
    }
}
