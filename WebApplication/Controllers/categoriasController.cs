using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriasController : ControllerBase
    {
        private readonly DataBaseContext _dbContext;

        public categoriasController(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext; 
        }

        [HttpGet("Get")]
        public IActionResult Llamar_Todo ()
        {
            var categoria = _dbContext.categorias.Where(c => c.Status == true).ToList();
            return Ok(categoria);
        } 

        [HttpPost("Post")]
        public IActionResult Insertar ([FromForm] Categoria categoriaRequets)
        {
            var name = categoriaRequets.Nombre;
            var ValidarNombre = _dbContext.categorias.Where(a => a.Nombre == name).FirstOrDefault();

            if (ValidarNombre != null) 
            {
                return BadRequest("La Categoria ya existe");
            }
            else
            {
                _dbContext.categorias.Add(categoriaRequets);
                _dbContext.SaveChanges();
                return Ok(categoriaRequets);
            }
        }

        [HttpPut("Put")]
        public IActionResult Actualizar([FromForm] Categoria categoriaRequest)
        {
            var Actualizar = _dbContext.categorias.Where(t =>
             t.CategoriaId ==
             categoriaRequest.CategoriaId).FirstOrDefault();

            if (Actualizar != null)
            {
               Actualizar.Nombre = categoriaRequest.Nombre;
                _dbContext.categorias.Update(Actualizar);
                _dbContext.SaveChanges();
                return Ok(Actualizar);
            }
            return StatusCode(400, "El elemento no se encuentra disponible");
        }

        [HttpDelete("Delete")]
        public IActionResult Eliminar([FromForm] Categoria categoriaRequest)
        {
            var Eliminar = _dbContext.categorias.Where(t => t.CategoriaId ==
            categoriaRequest.CategoriaId).FirstOrDefault();

            if (Eliminar  != null)
            {
                Eliminar.CategoriaId = categoriaRequest.CategoriaId;
                _dbContext.categorias.Remove(Eliminar);
                _dbContext.SaveChanges();
                return Ok(Eliminar);
            }
            return StatusCode(400, "El Elemento  no se encontro");
        }
    }
}
