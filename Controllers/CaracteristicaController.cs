using formulario.Entidades;
using formulario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace formulario.Controllers
{
    public class CaracteristicaController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CaracteristicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CaracteristicaList()
        {
            List<CaracteristicaModel> list =
                _context.Caracteristicas
                    .Select(p => new CaracteristicaModel()
                     {
                        Id = p.Id,
                        Name = p.Nombre,
                        Description = p.Descripcion,
                        Active = p.Activo,
                        CreationDate = p.FechaCreacion,
                        ProductModelId = p.ProductoId
                     })
                    .ToList();

            return View(list);
        }

        public IActionResult CaracteristicaAdd()
        {
            var model = new CaracteristicaModel();

            var productos = _context.Productos
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Nombre
                })
                .ToList();

            model.ListaProductos = productos;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CaracteristicaAdd(CaracteristicaModel Caracteristica)
        {
            var CaracteristicaEntity = new Caracteristica();
            CaracteristicaEntity.Id = Caracteristica.Id;
            CaracteristicaEntity.Nombre = Caracteristica.Name;
            CaracteristicaEntity.Descripcion = Caracteristica.Description;
            CaracteristicaEntity.Activo = Caracteristica.Active;
            CaracteristicaEntity.FechaCreacion = Caracteristica.CreationDate;
            CaracteristicaEntity.ProductoId = Caracteristica.ProductModelId;

            this._context.Caracteristicas.Add(CaracteristicaEntity);
            await this._context.SaveChangesAsync();

            return RedirectToAction("CaracteristicaList", "Caracteristica");
        }
        /*

        public IActionResult CaracteristicaEdit(Guid Id)
        {
            var Caracteristica = _context.Caracteristicas
                .Where(p => p.Id == Id).FirstOrDefault();

            if (Caracteristica == null)
            {
                return NotFound();
            }

            CaracteristicaModel model = new CaracteristicaModel();
            model.Id = Caracteristica.Id;
            model.Name = Caracteristica.Nombre;
            model.Quantity = Caracteristica.Cantidad;
            model.CreationDate = Caracteristica.FechaCreacion;

            return View(model);
        }

        [HttpPost]
        public IActionResult CaracteristicaEdit(CaracteristicaModel model)
        {
            var Caracteristica = _context.Caracteristicas
                .Where(p => p.Id == model.Id).FirstOrDefault();
                
            if (Caracteristica == null)
            {
                return NotFound();
            }

            Caracteristica.Nombre = model.Name;
            Caracteristica.Cantidad = model.Quantity;
            Caracteristica.FechaCreacion = model.CreationDate;

            _context.Caracteristicas.Update(Caracteristica);
            _context.SaveChanges();

            return RedirectToAction("CaracteristicaList", "Caracteristica");
        }

        public IActionResult CaracteristicaDelete(Guid Id)
        {
            var Caracteristica = _context.Caracteristicas
                .Where(p => p.Id == Id).FirstOrDefault();

            if (Caracteristica == null)
            {
                return NotFound();
            }

            _context.Caracteristicas.Remove(Caracteristica);
            _context.SaveChanges();

            return RedirectToAction("CaracteristicaList", "Caracteristica");
        }*/
    }
}
